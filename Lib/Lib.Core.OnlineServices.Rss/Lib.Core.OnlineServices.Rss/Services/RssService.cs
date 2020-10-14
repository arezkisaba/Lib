using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;

namespace Lib.Core.OnlineServices.Rss
{
    public class RssService : IRssService
    {
        private HttpService _httpService;

        public RssService(
            string url)
        {
            _httpService = new HttpService(url, ExchangeFormat.Xml);
        }

        public async Task<GetResponse> GetAsync()
        {
            return await _httpService.GetAsync<GetResponse>("");
        }
    }
}
