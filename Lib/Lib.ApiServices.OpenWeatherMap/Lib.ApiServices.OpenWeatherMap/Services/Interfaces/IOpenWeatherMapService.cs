using System.Threading.Tasks;

namespace Lib.ApiServices.OpenWeatherMap
{
    public interface IOpenWeatherMapService
    {
        Task<GetWeatherResponse> GetWeatherByTownAsync(string town);
    }
}
