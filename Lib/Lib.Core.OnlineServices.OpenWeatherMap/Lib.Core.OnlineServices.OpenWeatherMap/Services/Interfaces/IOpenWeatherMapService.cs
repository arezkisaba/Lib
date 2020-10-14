using System.Threading.Tasks;

namespace Lib.Core.OnlineServices.OpenWeatherMap
{
    public interface IOpenWeatherMapService
    {
        Task<GetWeatherResponse> GetWeatherByTownAsync(string town);
    }
}
