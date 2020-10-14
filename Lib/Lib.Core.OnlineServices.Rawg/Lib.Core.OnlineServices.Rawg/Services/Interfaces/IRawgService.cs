using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Core.OnlineServices.Rawg
{
    public interface IRawgService
    {
        Task<GetGameResponse> GetGameAsync(string id);
    }
}
