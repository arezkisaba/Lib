using System.Threading.Tasks;

namespace Lib.Core.OnlineServices.Rss
{
    public interface IRssService
    {
        Task<GetResponse> GetAsync();
    }
}
