using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Lib.ApiServices.Plex.UnitTests
{
    [TestClass]
    public class MainUnitTest
    {
        private IConfiguration _configuration;
        private IPlexApiService _plexService;

        public MainUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddUserSecrets<MainUnitTest>().Build();
        }

        [TestInitialize]
        public void Initialize()
        {
            _plexService = new PlexApiService(
                "http://127.0.0.1:32400/",
                _configuration["Plex.Username"],
                _configuration["Plex.Password"]);

            var identity = Assembly.GetExecutingAssembly().GetName().Name;
            _plexService.SetPlexProperties(identity, identity, identity, "V1");
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public async Task GetSectionsAsync_TestMethod()
        {
            var sections = await _plexService.GetSectionsAsync();
            Assert.IsTrue(sections.Any());
        }

        [TestMethod]
        public async Task GetMoviesAsync_TestMethod()
        {
            var sections = await _plexService.GetSectionsAsync();
            var movieSection = sections.First(obj => obj.type == "movie");
            var movies = await _plexService.GetMoviesAsync(movieSection.key.ToString());
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        public async Task GetTvShowsAsync_TestMethod()
        {
            var sections = await _plexService.GetSectionsAsync();
            var showSection = sections.First(obj => obj.type == "show");
            var tvshows = await _plexService.GetTvShowsAsync(showSection.key.ToString());
            Assert.IsTrue(tvshows.Any());
        }

        [TestMethod]
        public async Task GetSeasonsAsync_TestMethod()
        {
            var sections = await _plexService.GetSectionsAsync();
            var showSection = sections.First(obj => obj.type == "show");
            var tvshows = await _plexService.GetTvShowsAsync(showSection.key.ToString());
            var tvshow = tvshows.FirstOrDefault();
            var seasons = await _plexService.GetSeasonsAsync(tvshow.IdPlex);
            Assert.IsTrue(seasons.Any());
        }

        [TestMethod]
        public async Task GetEpisodesAsync_TestMethod()
        {
            var sections = await _plexService.GetSectionsAsync();
            var showSection = sections.First(obj => obj.type == "show");
            var tvshows = await _plexService.GetTvShowsAsync(showSection.key.ToString());
            var tvshow = tvshows.FirstOrDefault();
            var seasons = await _plexService.GetSeasonsAsync(tvshow.IdPlex);
            var season = seasons.FirstOrDefault();
            var episodes = await _plexService.GetEpisodesAsync(season.IdPlex);
            Assert.IsTrue(episodes.Any());
        }

        [TestMethod]
        public async Task RefreshSectionsAsync_TestMethod()
        {
            await _plexService.RefreshSectionsAsync();
        }
    }
}
