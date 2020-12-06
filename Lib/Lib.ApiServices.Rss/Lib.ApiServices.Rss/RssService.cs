using System.Threading.Tasks;
using Lib.Core;

namespace Lib.ApiServices.Rss
{
    public class RssService : IRssService
    {
        private HttpService _httpService;

        public RssService(string url)
        {
            _httpService = new HttpService(url, ExchangeFormat.Xml);
        }

        public async Task<GetResponse> GetAsync()
        {
            return await _httpService.GetAsync<GetResponse>("");
        }
    }
}
