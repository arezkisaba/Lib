using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace Lib.ApiServices.Trakt.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private IConfiguration _configuration;
        private ITraktApiService _traktService;

        public MainUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddUserSecrets<MainUnitTest>().Build();
        }

        [TestInitialize]
        public void Initialize()
        {
            _traktService = new TraktApiService(
                _configuration["Trakt.ApiKey"],
                _configuration["Trakt.ClientId"],
                _configuration["Trakt.ClientSecret"],
                _configuration["Trakt.Username"]);
            _traktService.AuthenticationInformationsAvailable += _traktService_AuthenticationInformationsAvailable;
            _traktService.AuthenticationSuccessfull += _traktService_AuthenticationSuccessfull;
        }

        private void _traktService_AuthenticationInformationsAvailable(object sender, AuthenticationInformations e)
        {
        }

        private void _traktService_AuthenticationSuccessfull(object sender, AuthenticationResult e)
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetAccountAsync_TestMethod()
        {
            var account = await _traktService.GetAccountAsync();
            Assert.IsTrue(account != null);
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMoviesCollectedAsync_TestMethod()
        {
            var movies = await _traktService.GetMoviesCollectedAsync();
            Assert.IsTrue(movies != null && movies.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMoviesWatchedAsync_TestMethod()
        {
            var movies = await _traktService.GetMoviesWatchedAsync();
            Assert.IsTrue(movies != null && movies.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMovieTranslationsAsync_TestMethod()
        {
            var movies = await _traktService.GetMoviesCollectedAsync();
            var translations = await _traktService.GetMovieTranslationsAsync(movies.FirstOrDefault(obj => obj.Title.Contains("Scary Movie 5")), "en");
            Assert.IsTrue(translations != null && translations.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowsCollectedAsync_TestMethod()
        {
            var tvShows = await _traktService.GetTvShowsCollectedAsync();
            Assert.IsTrue(tvShows != null && tvShows.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowsWatchedAsync_TestMethod()
        {
            var tvShows = await _traktService.GetTvShowsWatchedAsync();
            Assert.IsTrue(tvShows != null && tvShows.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowTranslationsAsync_TestMethod()
        {
            var tvshows = await _traktService.GetTvShowsCollectedAsync();
            var translations = await _traktService.GetTvShowTranslationsAsync(tvshows.First(), "fr");
            Assert.IsTrue(translations != null && translations.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetSeasonsInListAsync_TestMethod()
        {
            var seasons = await _traktService.GetSeasonsInListAsync("VOSTFR");
            Assert.IsTrue(seasons != null && seasons.Any());
        }
    }
}
