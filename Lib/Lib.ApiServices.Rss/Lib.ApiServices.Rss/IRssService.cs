using System.Threading.Tasks;

namespace Lib.ApiServices.Rss
{
    public interface IRssService
    {
        Task<GetResponse> GetAsync();
    }
}
