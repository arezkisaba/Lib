using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
            _kodiService = new KodiApiService(_configuration["Kodi.Url"]);
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        [DoNotParallelize]
        public void GetMoviesInLibraryAsync_TestMethod()
        {
            var movies = _kodiService.GetMoviesInLibraryAsync().Result;
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public void SetMovieWatchedAsync_TestMethod()
        {
            var movies = _kodiService.GetMoviesInLibraryAsync().Result;
            var firstMovie = movies.First(obj => obj.IsWatched);

            _kodiService.SetMovieWatchedAsync(firstMovie.Id, !firstMovie.IsWatched).Wait();

            var moviesUpdated = _kodiService.GetMoviesInLibraryAsync().Result;
            var firstMovieUpdated = moviesUpdated.First(obj => obj.Id == firstMovie.Id);
            var isUpdateOk = firstMovie.Id == firstMovieUpdated.Id && !firstMovie.IsWatched == firstMovieUpdated.IsWatched;
            Assert.IsTrue(isUpdateOk);

            _kodiService.SetMovieWatchedAsync(firstMovie.Id, firstMovie.IsWatched).Wait();
        }

        [TestMethod]
        [DoNotParallelize]
        public void GetTvShowsInLibraryAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsInLibraryAsync().Result;
            Assert.IsTrue(tvShows.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public void SetEpisodeWatchedAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsInLibraryAsync().Result;
            var firstTvShow = tvShows.First();
            var firstSeason = firstTvShow.Seasons.First();
            var firstEpisode = firstSeason.Episodes.First(obj => obj.IsWatched);

            _kodiService.SetEpisodeWatchedAsync(firstEpisode.Id, !firstEpisode.IsWatched).Wait();

            var tvShowsUpdated = _kodiService.GetTvShowsInLibraryAsync().Result;
            var firstTvShowUpdated = tvShowsUpdated.First();
            var firstSeasonUpdated = firstTvShowUpdated.Seasons.First();
            var firstEpisodeUpdated = firstSeasonUpdated.Episodes.First(obj => obj.Id == firstEpisode.Id);

            var isUpdateOk = firstEpisode.Id == firstEpisodeUpdated.Id && !firstEpisode.IsWatched == firstEpisodeUpdated.IsWatched;
            Assert.IsTrue(isUpdateOk);

            _kodiService.SetEpisodeWatchedAsync(firstEpisode.Id, firstEpisode.IsWatched).Wait();
        }
    }
}
