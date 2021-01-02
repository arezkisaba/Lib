using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.Kodi
{
    public interface IKodiApiService
    {
        Task<List<MovieDto>> GetMoviesInLibraryAsync();

        Task<SetMovieWatchedResponse> SetMovieWatchedAsync(string movieId, bool isWatched);

        Task<List<TvShowDto>> GetTvShowsInLibraryAsync();
        
        Task<SetEpisodeWatchedResponse> SetEpisodeWatchedAsync(string episodeId, bool isWatched);
    }
}
