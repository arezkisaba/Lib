using System.Threading.Tasks;
using Lib.Core;

namespace Lib.ApiServices.Rss
{
    public class RssApiService : IRssApiService
    {
        private HttpService _httpService;

        public RssApiService(string url)
        {
            _httpService = new HttpService(url, ExchangeFormat.Xml);
        }

        public async Task<GetResponse> GetAsync()
        {
            return await _httpService.GetAsync<GetResponse>("");
        }
    }
}
