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
            _kodiService = new KodiApiService("http://192.168.1.10:8080/jsonrpc");
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void GetMoviesAsync_TestMethod()
        {
            var movies = _kodiService.GetMoviesAsync().Result;
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        public void SetMoviesDetailsAsync_TestMethod()
        {
            var movies = _kodiService.GetMoviesAsync().Result;
            var firstMovie = movies.First();
            var newSortTitle = "sorttitle";
            var newPlayCount = 42;

            _kodiService.SetMoviesDetailsAsync(firstMovie.movieid, newSortTitle, newPlayCount).Wait();

            var moviesUpdated = _kodiService.GetMoviesAsync().Result;
            var firstMovieUpdated = moviesUpdated.First();

            var isUpdateOk = firstMovie.movieid == firstMovieUpdated.movieid &&
                newSortTitle == firstMovieUpdated.sorttitle &&
                newPlayCount == firstMovieUpdated.playcount;

            Assert.IsTrue(isUpdateOk);

            _kodiService.SetMoviesDetailsAsync(firstMovie.movieid, string.Empty, 0).Wait();
        }
    }
}
