using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.ApiServices.Milight.Enums;
using Lib.ApiServices.Milight.Services;
using Microsoft.Extensions.Configuration;

namespace Lib.ApiServices.Milight.Tests
{
    [TestClass]
    public class MainUnitTest
    {
        private IConfiguration _configuration;
        private MilightAdminService _milightAdminService;
        private MilightService _milightService;

        public MainUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddUserSecrets<MainUnitTest>().Build();
        }

        [TestInitialize]
        public void Initialize()
        {
            _milightAdminService = new MilightAdminService(_configuration["BulbHotspotIP"]);
            _milightService = new MilightService(_configuration["BulbHotspotIP"]);
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void RGBWSetColorAsync()
        {
            _milightService.RGBWSetColorAsync(MiLightGroups.All, 0xa0).Wait();
        }

        [TestMethod]
        public void RGBWSetDiscoModeAsync()
        {
            _milightService.RGBWSetDiscoModeAsync(MiLightGroups.All).Wait();
        }

        [TestMethod]
        public void RGBWSetNightModeAsync()
        {
            _milightService.RGBWSetNightModeAsync(MiLightGroups.All).Wait();
        }

        [TestMethod]
        public void RGBWSetWhiteModeAsync()
        {
            _milightService.RGBWSetWhiteModeAsync(MiLightGroups.All).Wait();
        }

        [TestMethod]
        public void RGBWSwitchOffAsync()
        {
            _milightService.RGBWSwitchOffAsync(MiLightGroups.All).Wait();
        }

        [TestMethod]
        public void RGBWSwitchOnAsync()
        {
            _milightService.RGBWSwitchOnAsync(MiLightGroups.All).Wait();
        }

        [TestMethod]
        public async void SetupAsync()
        {
            var bridges = await _milightAdminService.FindBridgesAsync();
            if (!bridges.Any())
            {
                return;
            }

            var bridgeIp = bridges.First().Value;
            var hotspots = await _milightAdminService.FindWifiHostspotsAsync();
            var version = await _milightAdminService.FindVersionAsync();
            var ssid = _configuration["SSID"];
            var wpaKey = _configuration["WPAKey"];
            var isStaSetupOk = await _milightAdminService.SetupHotspotAsync(hotspots.FirstOrDefault(obj => obj.Ssid == ssid).Ssid, wpaKey);
            if (isStaSetupOk)
            {
            }
        }
    }
}
