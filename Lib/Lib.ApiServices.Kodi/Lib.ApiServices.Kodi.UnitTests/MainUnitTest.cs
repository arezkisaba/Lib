using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Lib.ApiServices.Kodi.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private IConfiguration _configuration;
        private IKodiApiService _kodiService;

        public MainUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddUserSecrets<MainUnitTest>().Build();
        }

        [TestInitialize]
        public void Initialize()
        {
            _kodiService = new KodiApiService("http://127.0.0.1:8080/jsonrpc");
        }

        [TestCleanup]
        public void Cleanup()
        {
        }
    }
}
