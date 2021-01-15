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
            var torrendAdded = await _transmissionService.AddTorrentAsync("magnet:?xt=urn:btih:QM44R5JPMUQJVIOYRAX3Z2KKMC3N2UIS&tr=udp://tracker.opentrackr.org:1337/announce&tr=udp://open.stealth.si:80/announce&tr=http://tracker3.itzmx.com:8080/announce&tr=udp://explodie.org:6969/announce&tr=udp://exodus.desync.com:6969/announce&tr=udp://open.demonii.si:1337/announce&tr=udp://tracker.internetwarriors.net:1337/announce&tr=udp://ipv4.tracker.harry.lu:80/announce&tr=udp://tracker.tiny-vps.com:6969/announce&tr=udp://9.rarbg.me:2710/announce&tr=udp://9.rarbg.to:2740/announce&tr=udp://9.rarbg.com:2770/announce&tr=http://servandroidkino.ru/announce&tr=http://1337.abcvg.info/announce&tr=http://tracker.bittor.pw:1337/announce&tr=http://open.acgnxtracker.com/announce&tr=http://share.camoe.cn:8080/announce&tr=udp://tracker.torrent.eu.org:451/announce&tr=udp://tracker.cyberia.is:6969/announce&tr=udp://151.80.120.114:2710/announce&tr=http://tracker2.itzmx.com:6961/announce&tr=udp://tracker.yoshi210.com:6969/announce&tr=http://tracker.yoshi210.com:6969/announce&tr=http://torrentsmd.com:8080/announce&tr=udp://zephir.monocul.us:6969/announce&tr=udp://denis.stalker.upeer.me:6969/announce&tr=http://tracker.bt4g.com:2095/announce&tr=http://tracker.torrentyorg.pl/announce&tr=udp://tracker.leechers-paradise.org:6969/announce&tr=udp://opentor.org:2710/announce", Environment.GetEnvironmentVariable("Tmp"));
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
