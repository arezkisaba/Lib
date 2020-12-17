using System.Threading.Tasks;

namespace Lib.ApiServices.OpenWeatherMap
{
    public interface IOpenWeatherMapApiService
    {
        Task<GetWeatherResponse> GetWeatherByTownAsync(string town);
    }
}
