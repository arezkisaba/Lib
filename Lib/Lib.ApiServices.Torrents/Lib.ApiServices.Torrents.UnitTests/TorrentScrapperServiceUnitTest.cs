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
            var service = new GkTorrentTorrentScrapperService("https://vww.gktorrent.pw/");
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Dark S01 FRENCH");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task IdopeTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new IdopeTorrentScrapperService("https://www.idope.se/");
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Dark S01 FRENCH");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task OxTorrentTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new OxTorrentTorrentScrapperService("https://www.oxtorrent.co/");
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Dark S01 FRENCH");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task SkyTorrentsTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new SkyTorrentsTorrentScrapperService("https://www.skytorrents.lol/");
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Dark S01 FRENCH");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task Torrent9TorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new Torrent9TorrentScrapperService("https://www.torrent9.so/");
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Dark S01 FRENCH");
            Assert.IsTrue(torrents != null && torrents.Any());
        }

        [TestMethod]
        public async Task ZeTorrentsTorrentScrapperService_GetTorrentsByKeywordQueryAsync_TestMethod()
        {
            var service = new ZeTorrentsTorrentScrapperService("https://ww1.zetorrents.io/");
            var torrents = await service.GetTorrentsByKeywordQueryAsync("Dark S01 FRENCH");
            Assert.IsTrue(torrents != null && torrents.Any());
        }
    }
}
