using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.Kodi
{
    public interface IKodiApiService
    {
        Task<List<GetMoviesResponse.Movie>> GetMoviesAsync();
        Task<SetMovieDetailsResponse> SetMoviesDetailsAsync(int movieId, string sortTitle, int playCount);
    }
}
