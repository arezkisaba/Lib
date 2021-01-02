using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.ApiServices.TheMovieDatabase.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private IConfiguration _configuration;
        private ITheMovieDatabaseApiService _theMovieDatabaseApiService;

        public MainUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddUserSecrets<MainUnitTest>().Build();
        }

        [TestInitialize]
        public void Initialize()
        {
            _theMovieDatabaseApiService = new TheMovieDatabaseApiService(
                _configuration["TheMovieDatabase.ApiKey"],
                _configuration["TheMovieDatabase.AccessToken"],
                "");

            _theMovieDatabaseApiService.AuthenticationInformationsAvailable += (sender, e) =>
            {
            };

            _theMovieDatabaseApiService.AuthenticationSuccessfull += (sender, e) =>
            {
            };
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetAccountAsync_TestMethod()
        {
            var account = await _theMovieDatabaseApiService.GetAccountAsync();
            Assert.IsTrue(account != null);
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMoviesCollectedAsync_TestMethod()
        {
            var movies = await _theMovieDatabaseApiService.GetMoviesCollectedAsync();
            Assert.IsTrue(movies != null && movies.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMovieTranslationsAsync_TestMethod()
        {
            var movies = await _theMovieDatabaseApiService.GetMoviesCollectedAsync();
            var translations = await _theMovieDatabaseApiService.GetMovieTranslationsAsync(movies.FirstOrDefault(obj => obj.Title.Contains("Last Jedi")), "fr");
            Assert.IsTrue(translations != null && translations.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task PostMovieWatchedAsync_TestMethod()
        {
            var movies = await _theMovieDatabaseApiService.GetMoviesCollectedAsync();
            var response = await _theMovieDatabaseApiService.PostMovieWatchedAsync(movies.FirstOrDefault(obj => obj.Title.Contains("Skywalker")));
            Assert.IsTrue(response != null && response.status_code == 1);
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowsCollectedAsync_TestMethod()
        {
            var tvShows = await _theMovieDatabaseApiService.GetTvShowsCollectedAsync();
            Assert.IsTrue(tvShows != null && tvShows.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowTranslationsAsync_TestMethod()
        {
            var tvShows = await _theMovieDatabaseApiService.GetTvShowsCollectedAsync();
            var translations = await _theMovieDatabaseApiService.GetTvShowTranslationsAsync(tvShows.FirstOrDefault(obj => obj.Title.Contains("Bureau")), "fr");
            Assert.IsTrue(translations != null && translations.Any());
        }
    }
}
