using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.ApiServices.Milight.Enums;
using Lib.ApiServices.Milight.Models;

namespace Lib.ApiServices.Milight.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly MiLightAdminClient _miLightAdminClient = new MiLightAdminClient("10.10.100.254");
        private readonly MiLightClient _miLightClient = new MiLightClient("192.168.1.1");

        [TestMethod]
        public void RGBWSetColorAsync()
        {
            // _miLightClient.RGBWSetColorAsync(MiLightGroups.Two, (byte) ColorHelper.ColorToMiLightColor("#00FF00")).Wait();
        }

        [TestMethod]
        public void RGBWSetDiscoModeAsync()
        {
            _miLightClient.RGBWSetDiscoModeAsync(MiLightGroups.Two).Wait();
        }

        [TestMethod]
        public void RGBWSetNightModeAsync()
        {
            _miLightClient.RGBWSetNightModeAsync(MiLightGroups.Two).Wait();
        }

        [TestMethod]
        public void RGBWSetWhiteModeAsync()
        {
            _miLightClient.RGBWSetWhiteModeAsync(MiLightGroups.Two).Wait();
        }

        [TestMethod]
        public void RGBWSwitchOffAsync()
        {
            _miLightClient.RGBWSwitchOffAsync(MiLightGroups.Two).Wait();
        }

        [TestMethod]
        public void RGBWSwitchOnAsync()
        {
            _miLightClient.RGBWSwitchOnAsync(MiLightGroups.Two).Wait();
        }

        [TestMethod]
        public void Setup()
        {
            var bridges = _miLightAdminClient.FindBridgesAsync().GetAwaiter().GetResult();
            if (!bridges.Any())
            {
                return;
            }

            var bridgeIp = bridges.First().Value;
            var hotspots = _miLightAdminClient.FindHostspotsAsync(bridgeIp).GetAwaiter().GetResult();
            var version = _miLightAdminClient.FindVersionAsync(bridgeIp).GetAwaiter().GetResult();
            var isStaSetupOk = _miLightAdminClient.SetupHotspotAsync(bridgeIp, hotspots.FirstOrDefault(obj => obj.Ssid == "Bbox-00F68F1D").Ssid, "ilovejessicaalba").GetAwaiter().GetResult();
            if (isStaSetupOk)
            {
            }
        }

        [TestMethod]
        public void SyncArea2()
        {
        }

        [TestMethod]
        public void UnsyncArea2()
        {
        }
    }
}
