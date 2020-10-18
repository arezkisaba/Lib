using Lib.Core;
using System.Threading.Tasks;

namespace Lib.ApiServices.Rawg
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
