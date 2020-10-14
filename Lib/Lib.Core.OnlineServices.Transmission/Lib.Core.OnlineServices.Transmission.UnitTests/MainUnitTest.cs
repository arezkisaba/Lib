using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Core.OnlineServices.Transmission.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private ITransmissionService _transmissionService;

        [TestInitialize]
        public void Initialize()
        {
            _transmissionService = new TransmissionService("http://127.0.0.1:9091/");
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public async Task GetTorrentsAsync_TestMethod()
        {
            var torrents = await _transmissionService.GetTorrentsAsync();
            Assert.IsTrue(torrents != null && torrents.Any());
        }
    }
}
