using System.Threading.Tasks;

namespace Lib.Core.OnlineServices.OpenWeatherMap
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private string _apiKey;
        private HttpService _httpService;

        public OpenWeatherMapService(string apiKey)
        {
            _httpService = new HttpService("http://api.openweathermap.org/data/2.5/", ExchangeFormat.Json);
            _apiKey = apiKey;
        }

        public async Task<GetWeatherResponse> GetWeatherByTownAsync(string town)
        {
            return await _httpService.GetAsync<GetWeatherResponse>($"weather?q={town}&appid={_apiKey}");
        }
    }
}
