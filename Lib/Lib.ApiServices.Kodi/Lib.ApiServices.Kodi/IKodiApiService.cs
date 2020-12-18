using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.Kodi
{
    public interface IKodiApiService
    {
        Task<List<KodiMovieDto>> GetMoviesAsync();

        Task SetMovieDetailsAsync(int movieId, string sortTitle, bool? isWatched);

        Task<List<KodiTvShowDto>> GetTvShowsAsync();

        Task<List<KodiSeasonDto>> GetSeasonsAsync(int tvShowId);

        Task<List<KodiEpisodeDto>> GetEpisodesAsync(int tvShowId, int seasonId);

        Task SetTvShowDetailsAsync(int tvShowId, string sortTitle);

        Task SetEpisodeDetailsAsync(int episodeId, bool? isWatched);
    }
}