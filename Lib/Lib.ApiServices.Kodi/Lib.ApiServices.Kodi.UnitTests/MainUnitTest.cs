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
        public void GetMoviesAsync_TestMethod()
        {
            var movies = _kodiService.GetMoviesAsync().Result;
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        public void SetMovieDetailsAsync_TestMethod()
        {
            var movies = _kodiService.GetMoviesAsync().Result;
            var firstMovie = movies.First();
            var newSortTitle = "sorttitle";
            var newIsWatched = true;

            _kodiService.SetMovieDetailsAsync(firstMovie.Id, newSortTitle, newIsWatched).Wait();

            var moviesUpdated = _kodiService.GetMoviesAsync().Result;
            var firstMovieUpdated = moviesUpdated.First();

            var isUpdateOk = firstMovie.Id == firstMovieUpdated.Id &&
                newSortTitle == firstMovieUpdated.SortTitle &&
                newIsWatched == firstMovieUpdated.IsWatched;

            Assert.IsTrue(isUpdateOk);

            _kodiService.SetMovieDetailsAsync(firstMovie.Id, string.Empty, false).Wait();
        }

        [TestMethod]
        public void GetTvShowsWithEpisodesAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsWithEpisodesAsync().Result;
            Assert.IsTrue(tvShows.Any());
        }

        [TestMethod]
        public void GetTvShowAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsAsync().Result;
            Assert.IsTrue(tvShows.Any());
        }

        [TestMethod]
        public void GetSeasonsAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsAsync().Result;
            Assert.IsTrue(tvShows.Any());

            var tvShow = tvShows.First();
            var seasons = _kodiService.GetSeasonsAsync(tvShow.Id).Result;
            Assert.IsTrue(seasons.Any());
        }

        [TestMethod]
        public void GetEpisodesAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsAsync().Result;
            Assert.IsTrue(tvShows.Any());

            var tvShow = tvShows.First();//// (obj => obj.Id == 17);
            var seasons = _kodiService.GetSeasonsAsync(tvShow.Id).Result;
            Assert.IsTrue(seasons.Any());

            var season = seasons.First();
            var episodes = _kodiService.GetEpisodesAsync(tvShow.Id, season.Number).Result;
            Assert.IsTrue(episodes.Any());
        }

        [TestMethod]
        public void SetTvShowDetailsAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsAsync().Result;
            var firstTvShow = tvShows.First();
            var newSortTitle = "sorttitle";

            _kodiService.SetTvShowDetailsAsync(firstTvShow.Id, newSortTitle).Wait();

            var tvShowsUpdated = _kodiService.GetTvShowsAsync().Result;
            var firstTvShowUpdated = tvShowsUpdated.First();

            var isUpdateOk = firstTvShow.Id == firstTvShowUpdated.Id &&
                newSortTitle == firstTvShowUpdated.SortTitle;

            Assert.IsTrue(isUpdateOk);

            _kodiService.SetTvShowDetailsAsync(firstTvShow.Id, string.Empty).Wait();
        }

        [TestMethod]
        public void SetEpisodeDetailsAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsAsync().Result;
            var firstTvShow = tvShows.First();
            var seasons = _kodiService.GetSeasonsAsync(firstTvShow.Id).Result;
            var firstSeason = seasons.First();
            var episodes = _kodiService.GetEpisodesAsync(firstTvShow.Id, firstSeason.Id).Result;
            var firstEpisode = episodes.First();
            var newIsWatched = true;

            _kodiService.SetEpisodeDetailsAsync(firstEpisode.Id, newIsWatched).Wait();

            var episodesUpdated = _kodiService.GetEpisodesAsync(firstTvShow.Id, firstSeason.Id).Result;
            var firstEpisodeUpdated = episodesUpdated.First();

            var isUpdateOk = firstEpisode.Id == firstEpisodeUpdated.Id &&
                newIsWatched == firstEpisodeUpdated.IsWatched;

            Assert.IsTrue(isUpdateOk);

            _kodiService.SetEpisodeDetailsAsync(firstEpisode.Id, false).Wait();
        }
    }
}
