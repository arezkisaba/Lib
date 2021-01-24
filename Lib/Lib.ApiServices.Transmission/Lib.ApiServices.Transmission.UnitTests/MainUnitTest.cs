using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public async Task GetTorrentsAsync_AddTorrentAsync_DeleteTorrentAsync_TestMethod()
        {
            int? torrentId = null;
            var torrendAdded = await _transmissionService.AddTorrentAsync("C:\\Users\\sabaa\\AppData\\Roaming\\ryycysfmvr.torrent", Environment.GetEnvironmentVariable("Tmp"));
            if (torrendAdded?.arguments?.torrentadded != null)
            {
                torrentId = torrendAdded.arguments.torrentadded.id;
            }
            else if (torrendAdded?.arguments?.torrentduplicate != null)
            {
                torrentId = torrendAdded.arguments.torrentduplicate.id;
            }

            Assert.IsTrue(torrendAdded.result =="success" && (torrendAdded?.arguments?.torrentadded != null || torrendAdded?.arguments?.torrentduplicate != null));

            var torrents = await _transmissionService.GetTorrentsAsync();
            Assert.IsTrue(torrents != null && torrents.Any(obj => obj.id == torrentId));

            var torrentDeleted = await _transmissionService.DeleteTorrentAsync(torrentId.Value);
            Assert.IsTrue(torrentDeleted.result == "success");
        }
    }
}
