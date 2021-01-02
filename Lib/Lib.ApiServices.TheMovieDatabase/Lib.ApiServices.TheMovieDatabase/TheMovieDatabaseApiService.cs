using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net;
using Lib.Core;

namespace Lib.ApiServices.TheMovieDatabase
{
    public class TheMovieDatabaseApiService : ITheMovieDatabaseApiService
    {
        private HttpService _httpService;
        private string _apiKey;
        private string _accessToken;
        private string _sessionId;
        private string _accountId;
        public event EventHandler<AuthenticationResult> AuthenticationSuccessfull;
        public event EventHandler<AuthenticationInformations> AuthenticationInformationsAvailable;

        public TheMovieDatabaseApiService(string apiKey, string accessToken, string sessionId = null)
        {
            _apiKey = apiKey;
            _accessToken = accessToken;
            _sessionId = sessionId;

            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", $"Bearer {_accessToken}");

            _httpService = new HttpService("https://api.themoviedb.org/3/", ExchangeFormat.Json, headers);
            _httpService.AddCallbackForHttpStatusCode(HttpStatusCode.Unauthorized, AuthenticateAsync);
        }

        #region Authentication

        public async Task<GetRequestTokenResponse> GetRequestTokenAsync()
        {
            return await _httpService.GetAsync<GetRequestTokenResponse>($"authentication/token/new?api_key={_apiKey}");
        }

        public async Task<PostRequestTokenForSessionIdResponse> PostRequestTokenForSessionIdAsync(PostRequestTokenForSessionIdBody body)
        {
            return await _httpService.PostAsync<PostRequestTokenForSessionIdResponse>($"authentication/session/new?api_key={_apiKey}", body, disableCallbackAndRetry: true);
        }

        #endregion

        private async Task EnsureAccountInitializedAsync()
        {
            if (string.IsNullOrWhiteSpace(_accountId))
            {
                var account = await GetAccountAsync();
                _accountId = account.Id;
            }
        }

        #region Account

        public async Task<AccountDto> GetAccountAsync()
        {
            var responseObject = await _httpService.GetAsync<GetAccountResponse>($"account?api_key={_apiKey}");
            return new AccountDto().FromQueryResponse(responseObject);
        }

        #endregion

        #region Movies

        public async Task<List<MovieDto>> GetMoviesCollectedAsync()
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetMoviesCollectedResponse>($"account/{_accountId}/watchlist/movies?api_key={_apiKey}");
            var moviesCollected = responseObject.results.Select(obj => new MovieDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
            var moviesWatched = await GetMoviesWatchedAsync();

            foreach (var movieCollected in moviesCollected)
            {
                var match = moviesWatched.FirstOrDefault(obj => obj.Title == movieCollected.Title);
                if (match != null)
                {
                    movieCollected.IsWatched = true;
                }
            }

            return moviesCollected;
        }

        public async Task<List<MovieDto>> GetMoviesWatchedAsync()
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetMoviesWatchedResponse>($"account/{_accountId}/rated/movies?api_key={_apiKey}");
            return responseObject.results.Select(obj => new MovieDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<List<TranslationDto>> GetMovieTranslationsAsync(MovieDto movie, string language = null)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetMovieTranslationsResponse>($"movie/{movie.IdTheMovieDatabase}/translations?api_key={_apiKey}");
            return responseObject.translations.Select(obj => new TranslationDto().FromQueryResponse(obj)).Where(obj => language != null ? obj.Language == language : true).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<PostWatchedResponse> PostMovieWatchedAsync(MovieDto movie)
        {
            await EnsureAccountInitializedAsync();
            return await _httpService.PostAsync<PostWatchedResponse>($"movie/{movie.IdTheMovieDatabase}/rating?api_key={_apiKey}", new PostWatchedBody
            {
                value = 10
            });
        }

        public async Task<List<TvShowDto>> GetTvShowsCollectedAsync()
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetTvShowsCollectedResponse>($"account/{_accountId}/watchlist/tv?api_key={_apiKey}");
            var tvShows = responseObject.results.Select(obj => new TvShowDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
            var episodesWatched = await GetEpisodesWatchedAsync();
            foreach (var tvShow in tvShows)
            {
                var seasons = await GetSeasonsAsync(tvShow);
                foreach (var season in seasons)
                {
                    season.TvShow = tvShow;
                    var episodes = await GetEpisodesAsync(tvShow, season);
                    foreach (var episode in episodes)
                    {
                        episode.Season = season;
                        if (episodesWatched.Any(obj => tvShow.IdTheMovieDatabase == obj.Season.TvShow.IdTheMovieDatabase && season.Number == obj.Season.Number && episode.Number == obj.Number))
                        {
                            episode.IsWatched = true;
                        }
                    }

                    season.Episodes = episodes;
                }

                tvShow.Seasons = seasons;
            }

            return tvShows;
        }

        public async Task<List<EpisodeDto>> GetEpisodesWatchedAsync()
        {
            await EnsureAccountInitializedAsync();

            var items = new List<GetEpisodesWatchedResponse.Result>();
            var responseObject = await _httpService.GetAsync<GetEpisodesWatchedResponse>($"account/{_accountId}/rated/tv/episodes?api_key={_apiKey}");
            var pageCount = responseObject.total_pages;
            for (var i = 1; i <= pageCount; i++)
            {
                responseObject = await _httpService.GetAsync<GetEpisodesWatchedResponse>($"account/{_accountId}/rated/tv/episodes?api_key={_apiKey}&page={i}");
                items.AddRange(responseObject.results);

                System.Diagnostics.Debug.WriteLine(i);
            }

            return items.Select(obj => new EpisodeDto().FromQueryResponse(obj)).OrderBy(obj => obj.Number).ToList();
        }

        public async Task<List<TranslationDto>> GetTvShowTranslationsAsync(TvShowDto tvShow, string language = null)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetTvShowTranslationsResponse>($"tv/{tvShow.IdTheMovieDatabase}/translations?api_key={_apiKey}");
            return responseObject.translations.Select(obj => new TranslationDto().FromQueryResponse(obj)).Where(obj => language != null ? obj.Language == language : true).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<PostWatchedResponse> PostEpisodeWatchedAsync(TvShowDto tvShow, SeasonDto season, EpisodeDto episode)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SeasonDto>> GetSeasonsAsync(TvShowDto tvShow)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetSeasonsResponse>($"tv/{tvShow.IdTheMovieDatabase}?api_key={_apiKey}");
            return responseObject.seasons.Select(obj => new SeasonDto().FromQueryResponse(obj, tvShow.Title)).OrderBy(obj => obj.Number).Where(obj => obj.Number > 0).ToList();
        }

        public async Task<List<EpisodeDto>> GetEpisodesAsync(TvShowDto tvShow, SeasonDto season)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetEpisodesResponse>($"tv/{tvShow.IdTheMovieDatabase}/season/{season.Number}?api_key={_apiKey}");
            return responseObject.episodes.Select(obj => new EpisodeDto().FromQueryResponse(obj)).OrderBy(obj => obj.Number).Where(obj => obj.Number > 0).ToList();
        }

        #endregion

        private async Task AuthenticateAsync()
        {
            PostRequestTokenForSessionIdResponse postRequestTokenForSessionIdResponse = null;

            if (string.IsNullOrWhiteSpace(_sessionId))
            {
                var requestTokenResponse = await GetRequestTokenAsync();

                AuthenticationInformationsAvailable?.Invoke(this, new AuthenticationInformations
                {
                    AuthenticationUrl = $"https://www.themoviedb.org/authenticate/{requestTokenResponse.request_token}"
                });

                while (postRequestTokenForSessionIdResponse == null)
                {
                    try
                    {
                        postRequestTokenForSessionIdResponse = await PostRequestTokenForSessionIdAsync(new PostRequestTokenForSessionIdBody { request_token = requestTokenResponse.request_token });
                        _sessionId = postRequestTokenForSessionIdResponse.session_id;
                    }
                    catch (Exception)
                    {
                        await Task.Delay(2000);
                    }
                }
            }

            _httpService.AddQueryParameters($"&session_id={_sessionId}");

            AuthenticationSuccessfull?.Invoke(this, new AuthenticationResult
            {
                SessionId = _sessionId
            });
        }
    }

    public class AuthenticationInformations
    {
        public string AuthenticationUrl { get; set; }
    }

    public class AuthenticationResult
    {
        public string SessionId { get; set; }
    }
}

