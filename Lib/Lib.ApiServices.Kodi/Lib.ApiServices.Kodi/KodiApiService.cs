using Lib.Core;

namespace Lib.ApiServices.Kodi
{
    public class KodiApiService : IKodiApiService
    {
        private HttpService _httpService;
        private string _userName;
        private string _password;

        public KodiApiService(string url)
        {
            _httpService = new HttpService(url, ExchangeFormat.Json);
        }


    }
}
