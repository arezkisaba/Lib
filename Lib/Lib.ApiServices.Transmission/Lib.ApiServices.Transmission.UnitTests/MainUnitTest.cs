using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.ApiServices.Transmission.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private ITransmissionApiService _transmissionService;

        [TestInitialize]
        public void Initialize()
        {
            _transmissionService = new TransmissionApiService("http://127.0.0.1:9091/");
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
