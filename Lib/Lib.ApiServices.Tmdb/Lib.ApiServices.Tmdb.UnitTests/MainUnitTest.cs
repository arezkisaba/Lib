using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace Lib.ApiServices.Tmdb.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private IConfiguration _configuration;
        private ITmdbApiService _TmdbApiService;

        public MainUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddUserSecrets<MainUnitTest>().Build();
        }

        [TestInitialize]
        public async Task Initialize()
        {
            _TmdbApiService = new TmdbApiService(
                _configuration["Tmdb.ApiKey"],
                _configuration["Tmdb.AccessToken"],
                "44872b826e77f6e6558af6a3fbcde14a06934000");

            _TmdbApiService.AuthenticationInformationsAvailable += (sender, e) =>
            {
            };

            _TmdbApiService.AuthenticationSuccessfull += (sender, e) =>
            {
            };
        }

        [TestCleanup]
        public async Task Cleanup()
        {
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task SearchMovieAsync_TestMethod()
        {
            var movies = await _TmdbApiService.SearchMovieAsync("Star Wars: The Force Awakens");
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMoviesInLibraryAsync_TestMethod()
        {
            var movies = await _TmdbApiService.GetMoviesInLibraryAsync();
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMovieAsync_TestMethod()
        {
            var movie = await _TmdbApiService.GetMovieAsync("53182");
            Assert.IsTrue(movie != null);
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetMovieTranslationsAsync_TestMethod()
        {
            var movies = await _TmdbApiService.GetMoviesInLibraryAsync();
            var firstMovie = movies.First();
            var translations = await _TmdbApiService.GetMovieTranslationsAsync(firstMovie.Id, "fr");
            Assert.IsTrue(translations != null && translations.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task SetMovieWatchedAsync_TestMethod()
        {
            var movies = await _TmdbApiService.GetMoviesInLibraryAsync();
            var firstMovie = movies.First(obj => obj.IsWatched);

            await _TmdbApiService.SetMovieWatchedAsync(firstMovie.Id, !firstMovie.IsWatched);

            var moviesUpdated = await _TmdbApiService.GetMoviesInLibraryAsync();
            var firstMovieUpdated = moviesUpdated.First(obj => obj.Id == firstMovie.Id);
            var isUpdateOk = firstMovie.Id == firstMovieUpdated.Id && !firstMovie.IsWatched == firstMovieUpdated.IsWatched;
            Assert.IsTrue(isUpdateOk);

            await _TmdbApiService.SetMovieWatchedAsync(firstMovie.Id, firstMovie.IsWatched);
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task SearchTvShowAsync_TestMethod()
        {
            var tvShows = await _TmdbApiService.SearchTvShowAsync("The Bureau");
            Assert.IsTrue(tvShows.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowsInLibraryAsync_TestMethod()
        {
            var tvShows = await _TmdbApiService.GetTvShowsInLibraryAsync();
            Assert.IsTrue(tvShows.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowAsync_TestMethod()
        {
            var tvShow = await _TmdbApiService.GetTvShowAsync("31941");
            Assert.IsTrue(tvShow != null);
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task GetTvShowTranslationsAsync_TestMethod()
        {
            var tvShows = await _TmdbApiService.GetTvShowsInLibraryAsync();
            var firstTvShow = tvShows.First();
            var translations = await _TmdbApiService.GetTvShowTranslationsAsync(firstTvShow.Id, "fr");
            Assert.IsTrue(translations != null && translations.Any());
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task SetEpisodeWatchedAsync_TestMethod()
        {
            var tvShows = await _TmdbApiService.GetTvShowsInLibraryAsync();
            var firstTvShow = tvShows.First();
            var firstSeason = firstTvShow.Seasons.First();
            var firstEpisode = firstSeason.Episodes.First(obj => obj.IsWatched);

            await _TmdbApiService.SetEpisodeWatchedAsync(firstTvShow.Id, firstSeason.Number, firstEpisode.Number, !firstEpisode.IsWatched);

            var tvShowsUpdated = await _TmdbApiService.GetTvShowsInLibraryAsync();
            var firstTvShowUpdated = tvShowsUpdated.First();
            var firstSeasonUpdated = firstTvShowUpdated.Seasons.First();
            var firstEpisodeUpdated = firstSeasonUpdated.Episodes.First(obj => obj.Id == firstEpisode.Id);

            var isUpdateOk = firstEpisode.Id == firstEpisodeUpdated.Id && !firstEpisode.IsWatched == firstEpisodeUpdated.IsWatched;
            Assert.IsTrue(isUpdateOk);

            await _TmdbApiService.SetEpisodeWatchedAsync(firstTvShow.Id, firstSeason.Number, firstEpisode.Number, firstEpisode.IsWatched);
        }
    }
}
