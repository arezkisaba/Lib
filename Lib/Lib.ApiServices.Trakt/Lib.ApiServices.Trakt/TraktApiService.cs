using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net;
using Lib.Core;

namespace Lib.ApiServices.Trakt
{
    public class TraktApiService : ITraktApiService
    {
        private HttpService _httpService;
        private string _apiKey;
        private string _clientId;
        private string _clientSecret;
        private string _userName;
        private string _accessToken;
        private string _refreshToken;
        public event EventHandler<AuthenticationResult> AuthenticationSuccessfull;
        public event EventHandler<AuthenticationInformations> AuthenticationInformationsAvailable;

        public TraktApiService(string apiKey, string clientId, string clientSecret, string userName, string accessToken = null, string refreshToken = null)
        {
            _apiKey = apiKey;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _userName = userName;
            _accessToken = accessToken;
            _refreshToken = refreshToken;

            var headers = new Dictionary<string, string>();
            headers.Add("trakt-api-version", "2");
            headers.Add("trakt-api-key", _apiKey);

            if (_accessToken != null)
            {
                headers.Add("Authorization", $"Bearer {_accessToken}");
            }

            _httpService = new HttpService("https://api.trakt.tv/", ExchangeFormat.Json, headers);
            _httpService.AddCallbackForHttpStatusCode(HttpStatusCode.BadRequest, AuthenticateAsync);
            _httpService.AddCallbackForHttpStatusCode(HttpStatusCode.Unauthorized, AuthenticateAsync);
            _httpService.AddCallbackForHttpStatusCode(HttpStatusCode.InternalServerError, AuthenticateAsync);
        }

        #region Authentication

        public async Task<PostClientIdForDeviceCodeResponse> PostClientIdForDeviceCodeAsync(string clientId)
        {
            return await _httpService.PostAsync<PostClientIdForDeviceCodeResponse>($"oauth/device/code", new PostClientIdForDeviceCodeBody
            {
                client_id = clientId
            });
        }

        public async Task<PostDeviceCodeForAccessTokenResponse> PostDeviceCodeForAccessTokenAsync(string code, string clientId, string clientSecret)
        {
            return await _httpService.PostAsync<PostDeviceCodeForAccessTokenResponse>($"oauth/device/token", new PostDeviceCodeForAccessTokenBody
            {
                code = code,
                client_id = clientId,
                client_secret = clientSecret
            });
        }

        public async Task<PostRefreshTokenForAccessTokenResponse> PostRefreshTokenForAccessTokenAsync(string refreshToken)
        {
            return await _httpService.PostAsync<PostRefreshTokenForAccessTokenResponse>($"oauth/token", new PostRefreshTokenForAccessTokenBody
            {
                refresh_token = refreshToken,
                client_id = _clientId,
                client_secret = _clientSecret,
                redirect_uri = "http://google.fr",
                grant_type = "refresh_token",
            });
        }

        #endregion

        #region Account

        public async Task<AccountDto> GetAccountAsync()
        {
            var responseObject = await _httpService.GetAsync<GetAccountResponse>($"users/settings");
            return new AccountDto().FromQueryResponse(responseObject);
        }

        #endregion

        #region Movies

        public async Task<List<MovieDto>> GetMoviesCollectedAsync()
        {
            var responseObject = await _httpService.GetAsync<GetMoviesCollectedResponse.Item[]>($"users/{_userName}/collection/movies?extended=full");
            return responseObject.Select(obj => new MovieDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<List<MovieDto>> GetMoviesWatchedAsync()
        {
            var responseObject = await _httpService.GetAsync<GetMoviesWatchedResponse.Item[]>($"users/{_userName}/watched/movies?extended=full");
            return responseObject.Select(obj => new MovieDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<List<TranslationDto>> GetMovieTranslationsAsync(MovieDto movie, string language)
        {
            var responseObject = await _httpService.GetAsync<GetMovieTranslationsResponse.Item[]>($"movies/{movie.IdTrakt}/translations/{language}");
            return responseObject.Select(obj => new TranslationDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<PutWatchedResponse> PutMovieWatchedAsync(MovieDto movie)
        {
            return await _httpService.PostAsync<PutWatchedResponse>($"sync/history", new PutWatchedBody
            {
                movies = new PutWatchedBody.Movie[1]
                {
                    new PutWatchedBody.Movie
                    {
                        title = movie.Title,
                        year = movie.Year.Value,
                        ids = new PutWatchedBody.MovieIds
                        {
                            trakt = movie.IdTrakt,
                        }
                    }
                },
                episodes = new PutWatchedBody.Episode[0],
                shows = new PutWatchedBody.Show[0]
            });
        }

        #endregion

        #region TvShows
        
        public async Task<List<TvShowDto>> GetTvShowsCollectedAsync()
        {
            var responseObject = await _httpService.GetAsync<GetTvShowsCollectedResponse.Item[]>($"users/{_userName}/collection/shows?extended=full");
            return responseObject.Select(obj => new TvShowDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<List<TvShowDto>> GetTvShowsWatchedAsync()
        {
            var responseObject = await _httpService.GetAsync<GetTvShowsWatchedResponse.Item[]>($"users/{_userName}/watched/shows?extended=full");
            return responseObject.Select(obj => new TvShowDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }
        
        public async Task<List<TranslationDto>> GetTvShowTranslationsAsync(TvShowDto tvShow, string language)
        {
            var responseObject = await _httpService.GetAsync<GetTvShowTranslationsResponse.Item[]>($"shows/{tvShow.IdTrakt}/translations/{language}");
            return responseObject.Select(obj => new TranslationDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<PutCollectedResponse> PutTvShowCollectedAsync(TvShowDto tvShow)
        {
            return await _httpService.PostAsync<PutCollectedResponse>($"sync/collection", new PutCollectedBody
            {
                movies = new PutCollectedBody.Movie[0],
                episodes = new PutCollectedBody.Episode[0],
                shows = new PutCollectedBody.Show[1]
                {
                    new PutCollectedBody.Show
                    {
                        title = tvShow.Title,
                        year = tvShow.Year.Value,
                        ids = new PutCollectedBody.ShowIds
                        {
                            trakt = tvShow.IdTrakt
                        }
                    }
                }
            });
        }

        public async Task<PutWatchedResponse> PutTvShowWatchedAsync(TvShowDto tvShow)
        {
            return await _httpService.PostAsync<PutWatchedResponse>($"sync/history", new PutWatchedBody
            {
                movies = new PutWatchedBody.Movie[0],
                episodes = new PutWatchedBody.Episode[0],
                shows = new PutWatchedBody.Show[1]
                {
                    new PutWatchedBody.Show
                    {
                        title = tvShow.Title,
                        year = tvShow.Year.Value,
                        ids = new PutWatchedBody.ShowIds
                        {
                            trakt = tvShow.IdTrakt,
                        }
                    }
                }
            });
        }

        #endregion

        #region Seasons

        public async Task<List<SeasonDto>> GetSeasonsInListAsync(string listName)
        {
            var responseObject = await _httpService.GetAsync<GetSeasonsInListResponse.Item[]>($"users/{_userName}/lists/{listName}/items");
            return responseObject.Where(obj => obj.season != null).Select(obj => new SeasonDto().FromQueryResponse(obj)).OrderBy(obj => obj.TvShow.Title).ToList();
        }

        public async Task<PutWatchedResponse> PutSeasonWatchedAsync(SeasonDto season)
        {
            return await _httpService.PostAsync<PutWatchedResponse>($"sync/history", new PutWatchedBody
            {
                movies = new PutWatchedBody.Movie[0],
                episodes = new PutWatchedBody.Episode[0],
                shows = new PutWatchedBody.Show[1]
                {
                    new PutWatchedBody.Show
                    {
                        title = season.TvShow.Title,
                        year = season.TvShow.Year.Value,
                        ids = new PutWatchedBody.ShowIds
                        {
                            trakt = season.TvShow.IdTrakt,
                        },
                        seasons = new PutWatchedBody.Season[1]
                        {
                            new PutWatchedBody.Season
                            {
                                number = season.Number
                            }
                        }
                    }
                }
            });
        }

        #endregion

        #region Episodes

        public async Task<PutWatchedResponse> PutEpisodeWatchedAsync(EpisodeDto episode)
        {
            return await _httpService.PostAsync<PutWatchedResponse>($"sync/history", new PutWatchedBody
            {
                movies = new PutWatchedBody.Movie[0],
                episodes = new PutWatchedBody.Episode[0],
                shows = new PutWatchedBody.Show[1]
                {
                    new PutWatchedBody.Show
                    {
                        title = episode.Season.TvShow.Title,
                        year = episode.Season.TvShow.Year.Value,
                        ids = new PutWatchedBody.ShowIds
                        {
                            trakt = episode.Season.TvShow.IdTrakt,
                        },
                        seasons = new PutWatchedBody.Season[1]
                        {
                            new PutWatchedBody.Season
                            {
                                number = episode.Season.Number,
                                episodes = new PutWatchedBody.SeasonEpisode[1]
                                {
                                    new PutWatchedBody.SeasonEpisode
                                    {
                                        number = episode.Number
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        #endregion

        private async Task AuthenticateAsync()
        {
            if (string.IsNullOrWhiteSpace(_refreshToken))
            {
                var postClientIdForDeviceCodeResponse = await PostClientIdForDeviceCodeAsync(_clientId);
                PostDeviceCodeForAccessTokenResponse postDeviceCodeForAccessTokenResponse = null;

                AuthenticationInformationsAvailable?.Invoke(this, new AuthenticationInformations
                {
                    AuthenticationUrl = postClientIdForDeviceCodeResponse.verification_url,
                    DeviceCode = postClientIdForDeviceCodeResponse.user_code
                });

                while (postDeviceCodeForAccessTokenResponse == null)
                {
                    await Task.Delay(TimeHelper.FromSecondsToMilliseconds(postClientIdForDeviceCodeResponse.interval));

                    try
                    {
                        postDeviceCodeForAccessTokenResponse = await PostDeviceCodeForAccessTokenAsync(postClientIdForDeviceCodeResponse.device_code, _clientId, _clientSecret);
                        _accessToken = postDeviceCodeForAccessTokenResponse.access_token;
                        _refreshToken = postDeviceCodeForAccessTokenResponse.refresh_token;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                var postRefreshTokenForAccessTokenResponse = await PostRefreshTokenForAccessTokenAsync(_refreshToken);
                _accessToken = postRefreshTokenForAccessTokenResponse.access_token;
                _refreshToken = postRefreshTokenForAccessTokenResponse.refresh_token;
            }

            _httpService.AddHeader("Authorization", $"Bearer {_accessToken}");

            AuthenticationSuccessfull?.Invoke(this, new AuthenticationResult
            {
                AccessToken = _accessToken,
                RefreshToken = _refreshToken
            });
        }
    }

    public class AuthenticationResult
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }

    public class AuthenticationInformations
    {
        public string AuthenticationUrl { get; set; }

        public string DeviceCode { get; set; }
    }
}
