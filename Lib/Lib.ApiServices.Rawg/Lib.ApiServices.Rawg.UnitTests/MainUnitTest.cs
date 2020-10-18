using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Lib.ApiServices.Rawg.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private IRawgService _rawgService;

        [TestInitialize]
        public void Initialize()
        {
            _rawgService = new RawgService();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public async Task GetGameAsync_TestMethod()
        {
            var game = await _rawgService.GetGameAsync("4281");
            Assert.IsTrue(game != null);
        }
    }
}
