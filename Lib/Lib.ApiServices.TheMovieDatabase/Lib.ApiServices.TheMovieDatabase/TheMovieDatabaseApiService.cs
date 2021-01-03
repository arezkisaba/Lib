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

        public async Task<List<MovieDto>> SearchMovieAsync(string query)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<SearchMovieResponse>($"search/movie?api_key={_apiKey}&query={query}");
            return responseObject.results.Select(obj => new MovieDto().FromQueryResponse(obj)).ToList();
        }

        public async Task<List<MovieDto>> GetMoviesInLibraryAsync()
        {
            await EnsureAccountInitializedAsync();

            var responseObject = await _httpService.GetAsync<GetMoviesInLibraryResponse>($"account/{_accountId}/watchlist/movies?api_key={_apiKey}");
            var items = new List<GetMoviesInLibraryResponse.Result>();
            var pageCount = responseObject.total_pages;
            for (var i = 1; i <= pageCount; i++)
            {
                responseObject = await _httpService.GetAsync<GetMoviesInLibraryResponse>($"account/{_accountId}/watchlist/movies?api_key={_apiKey}&page={i}");
                items.AddRange(responseObject.results);
            }

            var moviesCollected = items.Select(obj => new MovieDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
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

        public async Task<MovieDto> GetMovieAsync(string movieId)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetMovieResponse>($"movie/{movieId}?api_key={_apiKey}");
            return new MovieDto().FromQueryResponse(responseObject);
        }

        public async Task<SetMovieWatchedResponse> SetMovieWatchedAsync(string movieId, bool isWatched)
        {
            await EnsureAccountInitializedAsync();

            if (isWatched)
            {
                var body = new SetMovieWatchedBody
                {
                    value = 10
                };

                return await _httpService.PostAsync<SetMovieWatchedResponse>($"movie/{movieId}/rating?api_key={_apiKey}", body);
            }
            else
            {
                return await _httpService.DeleteAsync<SetMovieWatchedResponse>($"movie/{movieId}/rating?api_key={_apiKey}");
            }
        }

        public async Task<List<TvShowDto>> SearchTvShowAsync(string query)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<SearchTvShowResponse>($"search/tv?api_key={_apiKey}&query={query}");
            return responseObject.results.Select(obj => new TvShowDto().FromQueryResponse(obj)).ToList();
        }

        public async Task<List<TvShowDto>> GetTvShowsInLibraryAsync()
        {
            await EnsureAccountInitializedAsync();

            var responseObject = await _httpService.GetAsync<GetTvShowsInLibraryResponse>($"account/{_accountId}/watchlist/tv?api_key={_apiKey}");
            var items = new List<GetTvShowsInLibraryResponse.Result>();
            var pageCount = responseObject.total_pages;
            for (var i = 1; i <= pageCount; i++)
            {
                responseObject = await _httpService.GetAsync<GetTvShowsInLibraryResponse>($"account/{_accountId}/watchlist/tv?api_key={_apiKey}&page={i}");
                items.AddRange(responseObject.results);
            }

            var tvShows = items.Select(obj => new TvShowDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
            var episodesWatched = await GetEpisodesWatchedAsync();
            foreach (var tvShow in tvShows)
            {
                var seasons = await GetSeasonsAsync(tvShow);
                foreach (var season in seasons)
                {
                    var episodes = await GetEpisodesAsync(tvShow, season);
                    foreach (var episode in episodes)
                    {
                        if (episodesWatched.Any(obj => episode.Id == obj.Id))
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

        public async Task<TvShowDto> GetTvShowAsync(string tvShowId)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetTvShowResponse>($"tv/{tvShowId}?api_key={_apiKey}");
            return new TvShowDto().FromQueryResponse(responseObject);
        }

        public async Task<SetEpisodeWatchedResponse> SetEpisodeWatchedAsync(string tvShowId, int seasonNumber, int episodeNumber, bool isWatched)
        {
            await EnsureAccountInitializedAsync();

            if (isWatched)
            {
                var body = new SetEpisodeWatchedBody
                {
                    value = 10
                };

                return await _httpService.PostAsync<SetEpisodeWatchedResponse>($"tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/rating?api_key={_apiKey}", body);
            }
            else
            {
                return await _httpService.DeleteAsync<SetEpisodeWatchedResponse>($"tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/rating?api_key={_apiKey}");
            }
        }

        public async Task<List<TranslationDto>> GetMovieTranslationsAsync(string movieId, string language = null)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetMovieTranslationsResponse>($"movie/{movieId}/translations?api_key={_apiKey}");
            return responseObject.translations.Select(obj => new TranslationDto().FromQueryResponse(obj)).Where(obj => language != null ? obj.Language == language : true).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<List<TranslationDto>> GetTvShowTranslationsAsync(string tvShowId, string language = null)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetTvShowTranslationsResponse>($"tv/{tvShowId}/translations?api_key={_apiKey}");
            return responseObject.translations.Select(obj => new TranslationDto().FromQueryResponse(obj)).Where(obj => language != null ? obj.Language == language : true).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<SetInLibraryResponse> SetInLibraryAsync(string mediaId, string mediaType)
        {
            await EnsureAccountInitializedAsync();

            var body = new SetInLibraryBody
            {
                media_id = int.Parse(mediaId),
                media_type = mediaType,
                watchlist = true
            };

            return await _httpService.PostAsync<SetInLibraryResponse>($"account/{_accountId}/watchlist?api_key={_apiKey}", body);
        }

        #region Internal use

        private async Task EnsureAccountInitializedAsync()
        {
            if (string.IsNullOrWhiteSpace(_accountId))
            {
                var account = await GetAccountAsync();
                _accountId = account.Id;
            }
        }

        private async Task<AccountDto> GetAccountAsync()
        {
            var responseObject = await _httpService.GetAsync<GetAccountResponse>($"account?api_key={_apiKey}");
            return new AccountDto().FromQueryResponse(responseObject);
        }

        private async Task<List<MovieDto>> GetMoviesWatchedAsync()
        {
            await EnsureAccountInitializedAsync();

            var responseObject = await _httpService.GetAsync<GetMoviesWatchedResponse>($"account/{_accountId}/rated/movies?api_key={_apiKey}");
            var items = new List<GetMoviesWatchedResponse.Result>();
            var pageCount = responseObject.total_pages;
            for (var i = 1; i <= pageCount; i++)
            {
                responseObject = await _httpService.GetAsync<GetMoviesWatchedResponse>($"account/{_accountId}/rated/movies?api_key={_apiKey}&page={i}");
                items.AddRange(responseObject.results);
            }

            return items.Select(obj => new MovieDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        private async Task<List<EpisodeDto>> GetEpisodesWatchedAsync()
        {
            await EnsureAccountInitializedAsync();

            var responseObject = await _httpService.GetAsync<GetEpisodesWatchedResponse>($"account/{_accountId}/rated/tv/episodes?api_key={_apiKey}");
            var items = new List<GetEpisodesWatchedResponse.Result>();
            var pageCount = responseObject.total_pages;
            for (var i = 1; i <= pageCount; i++)
            {
                responseObject = await _httpService.GetAsync<GetEpisodesWatchedResponse>($"account/{_accountId}/rated/tv/episodes?api_key={_apiKey}&page={i}");
                items.AddRange(responseObject.results);
            }

            return items.Select(obj => new EpisodeDto().FromQueryResponse(obj)).OrderBy(obj => obj.Number).ToList();
        }

        private async Task<List<SeasonDto>> GetSeasonsAsync(TvShowDto tvShow)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetSeasonsResponse>($"tv/{tvShow.Id}?api_key={_apiKey}");
            return responseObject.seasons.Select(obj => new SeasonDto().FromQueryResponse(obj, tvShow.Title)).OrderBy(obj => obj.Number).Where(obj => obj.Number > 0).ToList();
        }

        private async Task<List<EpisodeDto>> GetEpisodesAsync(TvShowDto tvShow, SeasonDto season)
        {
            await EnsureAccountInitializedAsync();
            var responseObject = await _httpService.GetAsync<GetEpisodesResponse>($"tv/{tvShow.Id}/season/{season.Number}?api_key={_apiKey}");
            return responseObject.episodes.Select(obj => new EpisodeDto().FromQueryResponse(obj)).OrderBy(obj => obj.Number).Where(obj => obj.Number > 0).ToList();
        }

        private async Task AuthenticateAsync()
        {
            SetRequestTokenForSessionIdResponse postRequestTokenForSessionIdResponse = null;

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
                        postRequestTokenForSessionIdResponse = await SetRequestTokenForSessionIdAsync(new SetRequestTokenForSessionIdBody { request_token = requestTokenResponse.request_token });
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

        private async Task<GetRequestTokenResponse> GetRequestTokenAsync()
        {
            return await _httpService.GetAsync<GetRequestTokenResponse>($"authentication/token/new?api_key={_apiKey}");
        }

        private async Task<SetRequestTokenForSessionIdResponse> SetRequestTokenForSessionIdAsync(SetRequestTokenForSessionIdBody body)
        {
            return await _httpService.PostAsync<SetRequestTokenForSessionIdResponse>($"authentication/session/new?api_key={_apiKey}", body, disableCallbackAndRetry: true);
        }

        #endregion
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

