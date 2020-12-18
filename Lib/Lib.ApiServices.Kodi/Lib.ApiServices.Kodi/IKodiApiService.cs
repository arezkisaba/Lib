using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.Kodi
{
    public interface IKodiApiService
    {
        Task<List<MovieDto>> GetMoviesAsync();
        Task SetMoviesDetailsAsync(int movieId, string sortTitle, int playCount);
    }
}
