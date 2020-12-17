using System.Threading.Tasks;

namespace Lib.ApiServices.Rss
{
    public interface IRssApiService
    {
        Task<GetResponse> GetAsync();
    }
}
