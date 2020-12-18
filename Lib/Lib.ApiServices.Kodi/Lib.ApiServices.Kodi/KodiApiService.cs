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

        public async Task<List<KodiMovieDto>> GetMoviesAsync()
        {
            var body = new GetMoviesBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetMovies",
                @params = new GetMoviesBody.Params
                {
                    properties = new string[]
                    {
                        "sorttitle",
                        "playcount",
                        "file"
                    }
                },
                id = "VideoLibrary.GetMovies"
            };

            var responseObject = await _httpService.PostAsync<GetMoviesResponse>($"", body);
            return responseObject.result.movies.OrderBy(obj => obj.label).Select(obj => new KodiMovieDto(obj.movieid, obj.label, obj.sorttitle, obj.playcount > 0, obj.file)).ToList();
        }

        public async Task SetMovieDetailsAsync(int movieId, string sortTitle, bool? isWatched)
        {
            var body = new SetMovieDetailsBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.SetMovieDetails",
                @params = new SetMovieDetailsBody.Params
                {
                    movieid = movieId,
                    sorttitle = sortTitle,
                    playcount = (!isWatched.HasValue ? null : (isWatched.Value ? 1 : 0)),
                },
                id = "VideoLibrary.SetMovieDetails"
            };


            await _httpService.PostAsync($"", body);
        }

        public async Task<List<KodiTvShowDto>> GetTvShowsWithEpisodesAsync()
        {
            var tvShows = await GetTvShowsAsync();
            foreach (var tvShow in tvShows)
            {
                var seasons = await GetSeasonsAsync(tvShow.Id);
                foreach (var season in seasons)
                {
                    var episodes = await GetEpisodesAsync(tvShow.Id, season.Id);
                    season.Episodes = episodes;
                }

                tvShow.Seasons = seasons;
            }

            return tvShows;
        }

        public async Task<List<KodiTvShowDto>> GetTvShowsAsync()
        {
            var body = new GetTvShowsBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetTVShows",
                @params = new GetTvShowsBody.Params
                {
                    properties = new string[]
                    {
                        "sorttitle",
                        "playcount",
                        "file"
                    }
                },
                id = "VideoLibrary.GetTVShows"
            };

            var responseObject = await _httpService.PostAsync<GetTvShowsResponse>($"", body);
            return responseObject.result.tvshows.OrderBy(obj => obj.label).Select(obj => new KodiTvShowDto(obj.tvshowid, obj.label, obj.sorttitle, obj.playcount > 0, obj.file)).ToList();
        }

        public async Task<List<KodiSeasonDto>> GetSeasonsAsync(int tvShowId)
        {
            var body = new GetSeasonsBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetSeasons",
                @params = new GetSeasonsBody.Params
                {
                    tvshowid = tvShowId,
                    properties = new string[]
                    {
                        "playcount",
                        "season"
                    }
                },
                id = "VideoLibrary.GetSeasons"
            };

            var responseObject = await _httpService.PostAsync<GetSeasonsResponse>($"", body);
            return responseObject.result.seasons.OrderBy(obj => obj.season).Select(obj => new KodiSeasonDto(obj.seasonid, obj.season, obj.playcount > 0)).ToList();
        }

        public async Task<List<KodiEpisodeDto>> GetEpisodesAsync(int tvShowId, int seasonId)
        {
            var body = new GetEpisodesBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetEpisodes",
                @params = new GetEpisodesBody.Params
                {
                    tvshowid = tvShowId,
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
            return responseObject.result.episodes.OrderBy(obj => obj.episode).Select(obj => new KodiEpisodeDto(obj.episodeid, obj.episode, obj.season, obj.playcount > 0, obj.file)).ToList();
        }

        public async Task SetTvShowDetailsAsync(int tvShowId, string sortTitle)
        {
            var body = new SetTvShowDetailsBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.SetTvShowDetails",
                @params = new SetTvShowDetailsBody.Params
                {
                    tvshowid = tvShowId,
                    sorttitle = sortTitle
                },
                id = "VideoLibrary.SetTvShowDetails"
            };


            await _httpService.PostAsync($"", body);
        }

        public async Task SetEpisodeDetailsAsync(int episodeId, bool? isWatched)
        {
            var body = new SetEpisodeDetailsBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.SetEpisodeDetails",
                @params = new SetEpisodeDetailsBody.Params
                {
                    episodeid = episodeId,
                    playcount = (!isWatched.HasValue ? null : (isWatched.Value ? 1 : 0)),
                },
                id = "VideoLibrary.SetEpisodeDetails"
            };


            await _httpService.PostAsync($"", body);
        }
    }
}
