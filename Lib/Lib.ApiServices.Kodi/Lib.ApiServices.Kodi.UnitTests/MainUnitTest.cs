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
            _kodiService = new KodiApiService("http://192.168.1.10:8080/jsonrpc");
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void GetMoviesAsync_TestMethod()
        {
            var items = _kodiService.GetMoviesAsync().Result;
            Assert.IsTrue(items.Any());
        }

        [TestMethod]
        public void SetMovieDetailsAsync_TestMethod()
        {
            var items = _kodiService.GetMoviesAsync().Result;
            var firstItem = items.First();
            var newSortTitle = "sorttitle";
            var newIsWatched = true;

            _kodiService.SetMovieDetailsAsync(firstItem.Id, newSortTitle, newIsWatched).Wait();

            var itemsUpdated = _kodiService.GetMoviesAsync().Result;
            var firstItemUpdated = itemsUpdated.First();

            var isUpdateOk = firstItem.Id == firstItemUpdated.Id &&
                newSortTitle == firstItemUpdated.SortTitle &&
                newIsWatched == firstItemUpdated.IsWatched;

            Assert.IsTrue(isUpdateOk);

            _kodiService.SetMovieDetailsAsync(firstItem.Id, string.Empty, false).Wait();
        }

        [TestMethod]
        public void GetTvShowsWithEpisodesAsync_TestMethod()
        {
            var tvShows = _kodiService.GetTvShowsWithEpisodesAsync().Result;
            foreach (var tvShow in tvShows)
            {
                Assert.IsTrue(tvShow.Seasons.Any());

                var hasAtLeastOneEpisodeInSeasons = false;
                foreach (var season in tvShow.Seasons)
                {
                    if (season.Episodes.Any())
                    {
                        hasAtLeastOneEpisodeInSeasons = true;
                    }
                }

                Assert.IsTrue(hasAtLeastOneEpisodeInSeasons);
            }
        }

        [TestMethod]
        public void GetTvShowAsync_TestMethod()
        {
            var items = _kodiService.GetTvShowsAsync().Result;
            Assert.IsTrue(items.Any());
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

            var tvShow = tvShows.First(obj => obj.Id == 81);
            var seasons = _kodiService.GetSeasonsAsync(tvShow.Id).Result;
            Assert.IsTrue(seasons.Any());

            var season = seasons.First();
            var episodes = _kodiService.GetEpisodesAsync(tvShow.Id, season.Id).Result;
            Assert.IsTrue(episodes.Any());
        }

        [TestMethod]
        public void SetTvShowDetailsAsync_TestMethod()
        {
            var items = _kodiService.GetTvShowsAsync().Result;
            var firstItem = items.First();
            var newSortTitle = "sorttitle";

            _kodiService.SetTvShowDetailsAsync(firstItem.Id, newSortTitle).Wait();

            var itemsUpdated = _kodiService.GetTvShowsAsync().Result;
            var firstItemUpdated = itemsUpdated.First();

            var isUpdateOk = firstItem.Id == firstItemUpdated.Id &&
                newSortTitle == firstItemUpdated.SortTitle;

            Assert.IsTrue(isUpdateOk);

            _kodiService.SetTvShowDetailsAsync(firstItem.Id, string.Empty).Wait();
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
