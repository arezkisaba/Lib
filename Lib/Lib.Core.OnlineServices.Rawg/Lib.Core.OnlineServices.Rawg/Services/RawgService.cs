using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Core.OnlineServices.Rawg
{
    public class RawgService : IRawgService
    {
        private HttpService _httpService;

        public RawgService()
        {
            _httpService = new HttpService("https://api.rawg.io/api/", ExchangeFormat.Json);
        }

        public async Task<GetGameResponse> GetGameAsync(string id)
        {
            return await _httpService.GetAsync<GetGameResponse>($"games/{id}");
        }
    }
}
