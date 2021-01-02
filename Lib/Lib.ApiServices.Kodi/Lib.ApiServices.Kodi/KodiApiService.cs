using Lib.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.ApiServices.Kodi
{
    public class KodiApiService : IKodiApiService
    {
        private HttpService _httpService;

        public KodiApiService(string url)
        {
            _httpService = new HttpService(url, ExchangeFormat.Json);
        }

        public async Task<List<MovieDto>> GetMoviesInLibraryAsync()
        {
            var body = new GetMoviesInLibraryBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetMovies",
                @params = new GetMoviesInLibraryBody.Params
                {
                    properties = new string[]
                    {
                        "playcount",
                        "file"
                    }
                },
                id = "VideoLibrary.GetMovies"
            };

            var responseObject = await _httpService.PostAsync<GetMoviesInLibraryResponse>($"", body);
            return responseObject.result.movies.Select(obj => new MovieDto().FromQueryResponse(obj)).OrderBy(obj => obj.Title).ToList();
        }

        public async Task<SetMovieWatchedResponse> SetMovieWatchedAsync(string movieId, bool isWatched)
        {
            var body = new SetMovieWatchedBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.SetMovieDetails",
                @params = new SetMovieWatchedBody.Params
                {
                    movieid = int.Parse(movieId),
                    playcount = isWatched ? 1 : 0,
                },
                id = "VideoLibrary.SetMovieDetails"
            };


            return await _httpService.PostAsync<SetMovieWatchedResponse>($"", body);
        }

        public async Task<List<TvShowDto>> GetTvShowsInLibraryAsync()
        {
            var tvShows = await GetTvShowsAsync();
            foreach (var tvShow in tvShows)
            {
                var seasons = await GetSeasonsAsync(tvShow.Id);
                foreach (var season in seasons)
                {
                    var episodes = await GetEpisodesAsync(tvShow.Id, season.Number);
                    season.Episodes = episodes;
                }

                tvShow.Seasons = seasons;
            }

            return tvShows;
        }

        public async Task<SetEpisodeWatchedResponse> SetEpisodeWatchedAsync(string episodeId, bool isWatched)
        {
            var body = new SetEpisodeWatchedBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.SetEpisodeDetails",
                @params = new SetEpisodeWatchedBody.Params
                {
                    episodeid = int.Parse(episodeId),
                    playcount = isWatched ? 1 : 0,
                },
                id = "VideoLibrary.SetEpisodeDetails"
            };


            return await _httpService.PostAsync<SetEpisodeWatchedResponse>($"", body);
        }

        #region Internal use

        private async Task<List<TvShowDto>> GetTvShowsAsync()
        {
            var body = new GetTvShowsBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetTVShows",
                @params = new GetTvShowsBody.Params
                {
                    properties = new string[]
                    {
                        "file"
                    }
                },
                id = "VideoLibrary.GetTVShows"
            };

            var responseObject = await _httpService.PostAsync<GetTvShowsResponse>($"", body);
            return responseObject.result.tvshows.OrderBy(obj => obj.label).Select(obj => new TvShowDto().FromQueryResponse(obj)).ToList();
        }

        private async Task<List<SeasonDto>> GetSeasonsAsync(string tvShowId)
        {
            var body = new GetSeasonsBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetSeasons",
                @params = new GetSeasonsBody.Params
                {
                    tvshowid = int.Parse(tvShowId),
                    properties = new string[]
                    {
                        "season"
                    }
                },
                id = "VideoLibrary.GetSeasons"
            };

            var responseObject = await _httpService.PostAsync<GetSeasonsResponse>($"", body);
            return responseObject.result.seasons.OrderBy(obj => obj.season).Select(obj => new SeasonDto().FromQueryResponse(obj)).ToList();
        }

        private async Task<List<EpisodeDto>> GetEpisodesAsync(string tvShowId, int seasonId)
        {
            var body = new GetEpisodesBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetEpisodes",
                @params = new GetEpisodesBody.Params
                {
                    tvshowid = int.Parse(tvShowId),
                    season = seasonId,
                    properties = new string[]
                    {
                        "playcount",
                        "file",
                        "episode",
                        "season"
                    }
                },
                id = "VideoLibrary.GetEpisodes"
            };

            var responseObject = await _httpService.PostAsync<GetEpisodesResponse>($"", body);
            return responseObject.result.episodes.OrderBy(obj => obj.episode).Select(obj => new EpisodeDto().FromQueryResponse(obj)).ToList();
        }

        #endregion
    }
}
