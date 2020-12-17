using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.ApiServices.Rss.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private IRssApiService _rssService;

        [TestInitialize]
        public void Initialize()
        {
            // https://www6.lequipe.fr/rss/actu_rss.xml
            // https://www.monde-diplomatique.fr/recents.xml
            // https://www.matchendirect.fr/rss/
            // https://www.acrimed.org/spip.php?page=backend
            // http://feeds.feedburner.com/agoravox/gEOF
            // https://www.alternatives-economiques.fr/rss.xml
            // http://www.economiematin.fr/flux/alaune.xml
            // https://www.francetvinfo.fr/titres.rss
            // http://www.maviemobile.fr/rss/
            // https://www.sciencesetavenir.fr/rss.xml
            // https://www.insee.fr/fr/flux/10
            _rssService = new RssApiService("https://www.monde-diplomatique.fr/recents.xml");
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public async Task GetAsync_TestMethod()
        {
            var rss = await _rssService.GetAsync();
            Assert.IsTrue(rss != null && rss.channel.item.Any());
        }
    }
}
