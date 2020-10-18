using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.Rawg
{
    public interface IRawgService
    {
        Task<GetGameResponse> GetGameAsync(string id);
    }
}
