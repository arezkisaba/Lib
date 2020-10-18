using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Lib.ApiServices.OpenWeatherMap.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private IConfiguration _configuration;
        private IOpenWeatherMapService _openWeatherMapService;

        public MainUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddUserSecrets<MainUnitTest>().Build();
        }

        [TestInitialize]
        public void Initialize()
        {
            _openWeatherMapService = new OpenWeatherMapService(
                _configuration["OpenWeatherMap.ApiKey"]);
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public async Task GetWeatherByTownAsync_TestMethod()
        {
            var weather = await _openWeatherMapService.GetWeatherByTownAsync("Paris");
            Assert.IsTrue(weather != null);
        }
    }
}
