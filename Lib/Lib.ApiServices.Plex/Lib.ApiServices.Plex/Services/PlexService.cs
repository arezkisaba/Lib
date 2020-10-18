using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Net.Http;
using System.Net;
using Lib.Core;

namespace Lib.ApiServices.Plex
{
    public class PlexService : IPlexService
    {
        private const string SignInUrl = "https://plex.tv/users/sign_in.xml";
        private HttpService _httpService;
        private string _userName;
        private string _password;
        private string _accessToken;
        private string _plexClientIdentifier;
        private string _plexDeviceName;
        private string _plexProduct;
        private string _plexVersion;
        public event EventHandler<AuthenticationResult> AuthenticationSuccessfull;

        public PlexService(string url, string userName, string password, string accessToken = null)
        {
            _userName = userName;
            _password = password;
            _accessToken = accessToken;

            var headers = new Dictionary<string, string>();

            if (_accessToken != null)
            {
                headers.Add("X-Plex-Token", $"Bearer {_accessToken}");
            }

            _httpService = new HttpService(url, ExchangeFormat.Xml, headers);
            _httpService.AddCallbackForHttpStatusCode(HttpStatusCode.Unauthorized, AuthenticateAsync);
        }

        public void SetPlexProperties(string plexClientIdentifier, string plexDeviceName, string plexProduct, string plexVersion)
        {
            _plexClientIdentifier = plexClientIdentifier;
            _plexDeviceName = plexDeviceName;
            _plexProduct = plexProduct;
            _plexVersion = plexVersion;
        }

        #region Sections

        public async Task<List<GetSectionsResponse.MediaContainerDirectory>> GetSectionsAsync()
        {
            var responseObject = await _httpService.GetAsync<GetSectionsResponse.MediaContainer>($"library/sections");
            return responseObject.Directories.ToList();
        }

        #endregion

        #region Movies

        public async Task<List<MovieDto>> GetMoviesAsync(string libraryId)
        {
            var responseObject = await _httpService.GetAsync<GetMoviesResponse.MediaContainer>($"library/sections/{libraryId}/all");
            return responseObject.Video.Where(obj => !string.IsNullOrWhiteSpace(obj.ratingKey)).Select(obj => new MovieDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task PutMovieLockedAsync(string libraryId, string mediaId, string mediaTitle)
        {
            mediaTitle = UriHelper.Encode(mediaTitle);
            await _httpService.PutAsync($"library/sections/{libraryId}/all?type=1&id={mediaId}&titleSort.value={mediaTitle}&titleSort.locked=1&title.locked=1", null);
        }

        public async Task PutMovieWatchedAsync(string mediaId)
        {
            await _httpService.PutAsync($":/scrobble?identifier=com.plexapp.plugins.library&key={mediaId}", null);
        }

        #endregion

        #region TvShows

        public async Task<List<TvShowDto>> GetTvShowsAsync(string libraryId)
        {
            var responseObject = await _httpService.GetAsync<GetTvShowsResponse.MediaContainer>($"library/sections/{libraryId}/all?type=2");
            if (responseObject.Directory == null)
            {
                responseObject.Directory = new GetTvShowsResponse.MediaContainerDirectory[0];
            }

            return responseObject.Directory.Where(obj => !string.IsNullOrWhiteSpace(obj.ratingKey)).Select(obj => new TvShowDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task PutTvShowLockedAsync(string libraryId, string mediaId, string mediaTitle)
        {
            mediaTitle = UriHelper.Encode(mediaTitle);
            await _httpService.PutAsync($"library/sections/{libraryId}/all?type=2&id={mediaId}&titleSort.value={mediaTitle}&titleSort.locked=1&title.locked=1", null);
        }

        #endregion

        #region Seasons

        public async Task<List<SeasonDto>> GetSeasonsAsync(string tvShowId)
        {
            var responseObject = await _httpService.GetAsync<GetSeasonsResponse.MediaContainer>($"library/metadata/{tvShowId}/children");
            if (responseObject.Directory == null)
            {
                responseObject.Directory = new GetSeasonsResponse.MediaContainerDirectory[0];
            }

            return responseObject.Directory.Where(obj => !string.IsNullOrWhiteSpace(obj.ratingKey)).Select(obj => new SeasonDto().FromQueryResponse(obj)).ToList();
        }

        #endregion

        #region Episodes

        public async Task<List<EpisodeDto>> GetEpisodesAsync(string seasonId)
        {
            var responseObject = await _httpService.GetAsync<GetEpisodesResponse.MediaContainer>($"library/metadata/{seasonId}/children");
            return responseObject.Video.Where(obj => !string.IsNullOrWhiteSpace(obj.ratingKey)).Select(obj => new EpisodeDto().FromQueryResponse(obj)).ToList();
        }

        public async Task PutEpisodeWatchedAsync(string mediaId)
        {
            await _httpService.PutAsync($":/scrobble?identifier=com.plexapp.plugins.library&key={mediaId}", null);
        }

        #endregion

        #region Misc

        public async Task RefreshSectionsAsync()
        {
            await _httpService.GetStringAsync($"library/sections/all/refresh");
        }

        #endregion

        public async Task AuthenticateAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_userName}:{_password}"))}");
            httpClient.DefaultRequestHeaders.Add("X-Plex-Client-Identifier", _plexClientIdentifier);
            httpClient.DefaultRequestHeaders.Add("X-Plex-Device-Name", _plexDeviceName);
            httpClient.DefaultRequestHeaders.Add("X-Plex-Product", _plexProduct);
            httpClient.DefaultRequestHeaders.Add("X-Plex-Version", _plexVersion);
            var response = await httpClient.PostAsync(SignInUrl, null);
            var content = await response.Content.ReadAsStringAsync();
            var result = await Serializer.XmlDeserializeAsync<PostAuthenticationResponse.user>(content);
            _accessToken = result.authenticationToken;
            _httpService.AddHeader("X-Plex-Token", _accessToken);

            AuthenticationSuccessfull?.Invoke(this, new AuthenticationResult
            {
                AccessToken = _accessToken,
            });
        }
    }

    public class AuthenticationResult
    {
        public string AccessToken { get; set; }
    }
}
