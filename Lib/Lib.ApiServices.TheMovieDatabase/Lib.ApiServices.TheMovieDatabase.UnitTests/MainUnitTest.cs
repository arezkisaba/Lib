using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

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
                "44872b826e77f6e6558af6a3fbcde14a06934000");

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
        public void GetMoviesInLibraryAsync_TestMethod()
        {
            var movies = _theMovieDatabaseApiService.GetMoviesInLibraryAsync().Result;
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public void SetMovieWatchedAsync_TestMethod()
        {
            var movies = _theMovieDatabaseApiService.GetMoviesInLibraryAsync().Result;
            var firstMovie = movies.First(obj => obj.IsWatched);

            _theMovieDatabaseApiService.SetMovieWatchedAsync(firstMovie.Id, !firstMovie.IsWatched).Wait();

            var moviesUpdated = _theMovieDatabaseApiService.GetMoviesInLibraryAsync().Result;
            var firstMovieUpdated = moviesUpdated.First(obj => obj.Id == firstMovie.Id);
            var isUpdateOk = firstMovie.Id == firstMovieUpdated.Id && !firstMovie.IsWatched == firstMovieUpdated.IsWatched;
            Assert.IsTrue(isUpdateOk);

            _theMovieDatabaseApiService.SetMovieWatchedAsync(firstMovie.Id, firstMovie.IsWatched).Wait();
        }

        [TestMethod]
        [DoNotParallelize]
        public void GetTvShowsInLibraryAsync_TestMethod()
        {
            var tvShows = _theMovieDatabaseApiService.GetTvShowsInLibraryAsync().Result;
            Assert.IsTrue(tvShows.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public void SetEpisodeWatchedAsync_TestMethod()
        {
            var tvShows = _theMovieDatabaseApiService.GetTvShowsInLibraryAsync().Result;
            var firstTvShow = tvShows.First();
            var firstSeason = firstTvShow.Seasons.First();
            var firstEpisode = firstSeason.Episodes.First(obj => obj.IsWatched);

            _theMovieDatabaseApiService.SetEpisodeWatchedAsync(firstTvShow.Id, firstSeason.Number, firstEpisode.Number, !firstEpisode.IsWatched).Wait();

            var tvShowsUpdated = _theMovieDatabaseApiService.GetTvShowsInLibraryAsync().Result;
            var firstTvShowUpdated = tvShowsUpdated.First();
            var firstSeasonUpdated = firstTvShowUpdated.Seasons.First();
            var firstEpisodeUpdated = firstSeasonUpdated.Episodes.First(obj => obj.Id == firstEpisode.Id);

            var isUpdateOk = firstEpisode.Id == firstEpisodeUpdated.Id && !firstEpisode.IsWatched == firstEpisodeUpdated.IsWatched;
            Assert.IsTrue(isUpdateOk);

            _theMovieDatabaseApiService.SetEpisodeWatchedAsync(firstTvShow.Id, firstSeason.Number, firstEpisode.Number, firstEpisode.IsWatched).Wait();
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMovieTranslationsAsync_TestMethod()
        {
            var movies = await _theMovieDatabaseApiService.GetMoviesInLibraryAsync();
            var firstMovie = movies.First();
            var translations = await _theMovieDatabaseApiService.GetMovieTranslationsAsync(firstMovie.Id, "fr");
            Assert.IsTrue(translations != null && translations.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowTranslationsAsync_TestMethod()
        {
            var tvShows = await _theMovieDatabaseApiService.GetTvShowsInLibraryAsync();
            var firstTvShow = tvShows.First();
            var translations = await _theMovieDatabaseApiService.GetTvShowTranslationsAsync(firstTvShow.Id, "fr");
            Assert.IsTrue(translations != null && translations.Any());
        }
    }
}
