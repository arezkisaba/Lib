using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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
        public async Task Initialize()
        {
            _kodiService = new KodiApiService(_configuration["Kodi.Url"]);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMoviesInLibraryAsync_TestMethod()
        {
            var movies = await _kodiService.GetMoviesInLibraryAsync();
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task SetMovieWatchedAsync_TestMethod()
        {
            var movies = await _kodiService.GetMoviesInLibraryAsync();
            var firstMovie = movies.First(obj => obj.IsWatched);

            await _kodiService.SetMovieWatchedAsync(firstMovie.Id, !firstMovie.IsWatched);

            var moviesUpdated = await _kodiService.GetMoviesInLibraryAsync();
            var firstMovieUpdated = moviesUpdated.First(obj => obj.Id == firstMovie.Id);
            var isUpdateOk = firstMovie.Id == firstMovieUpdated.Id && !firstMovie.IsWatched == firstMovieUpdated.IsWatched;
            Assert.IsTrue(isUpdateOk);

            await _kodiService.SetMovieWatchedAsync(firstMovie.Id, firstMovie.IsWatched);
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowsInLibraryAsync_TestMethod()
        {
            var tvShows = await _kodiService.GetTvShowsInLibraryAsync();
            Assert.IsTrue(tvShows.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task SetEpisodeWatchedAsync_TestMethod()
        {
            var tvShows = await _kodiService.GetTvShowsInLibraryAsync();
            var firstTvShow = tvShows.First();
            var firstSeason = firstTvShow.Seasons.First();
            var firstEpisode = firstSeason.Episodes.First(obj => obj.IsWatched);

            await _kodiService.SetEpisodeWatchedAsync(firstEpisode.Id, !firstEpisode.IsWatched);

            var tvShowsUpdated = await _kodiService.GetTvShowsInLibraryAsync();
            var firstTvShowUpdated = tvShowsUpdated.First();
            var firstSeasonUpdated = firstTvShowUpdated.Seasons.First();
            var firstEpisodeUpdated = firstSeasonUpdated.Episodes.First(obj => obj.Id == firstEpisode.Id);

            var isUpdateOk = firstEpisode.Id == firstEpisodeUpdated.Id && !firstEpisode.IsWatched == firstEpisodeUpdated.IsWatched;
            Assert.IsTrue(isUpdateOk);

            await _kodiService.SetEpisodeWatchedAsync(firstEpisode.Id, firstEpisode.IsWatched);
        }
    }
}
