using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.Kodi
{
    public interface IKodiApiService
    {
        Task<List<MovieDto>> GetMoviesAsync();

        Task SetMovieDetailsAsync(int movieId, string sortTitle, bool? isWatched);

        Task<List<TvShowDto>> GetTvShowsWithEpisodesAsync();
        
        Task<List<TvShowDto>> GetTvShowsAsync();

        Task<List<SeasonDto>> GetSeasonsAsync(int tvShowId);

        Task<List<EpisodeDto>> GetEpisodesAsync(int tvShowId, int seasonId);

        Task SetTvShowDetailsAsync(int tvShowId, string sortTitle);

        Task SetEpisodeDetailsAsync(int episodeId, bool? isWatched);
    }
}