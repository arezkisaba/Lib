using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.ApiServices.Torrents.UnitTests
{
    [TestClass]
    public class TorrentScrapperServiceUnitTest
    {
        [TestMethod]
        public async Task GkTorrentTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new GkTorrentTorrentScrapperService();
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Game of Thrones");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task IdopeTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new IdopeTorrentScrapperService();
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Game of Thrones");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task OxTorrentTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new OxTorrentTorrentScrapperService();
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Game of Thrones");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task SkyTorrentsTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new SkyTorrentsTorrentScrapperService();
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Game of Thrones");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task Torrent9TorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new Torrent9TorrentScrapperService();
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Game of Thrones");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task ZeTorrentsTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new ZeTorrentsTorrentScrapperService();
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Game of Thrones");
            Assert.IsTrue(torrents != null && torrents.Any());
        }
    }
}
