using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Core.UnitTests
{
    [TestClass]
    public class HttpServiceUnitTest
    {
        ////private string _serviceUrl = "https://localhost:5001/";
        private string _serviceUrl = "https://libcoresampleswebapi.azurewebsites.net/";

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public async Task AllRestVerbsAsync_Json_TestMethod()
        {
            await ProcessAsync(ExchangeFormat.Json);
        }

        [TestMethod]
        public async Task AllRestVerbsAsync_Xml_TestMethod()
        {
            await ProcessAsync(ExchangeFormat.Xml);
        }

        private async Task ProcessAsync(ExchangeFormat exchangeFormat)
        {
            var httpService = new HttpService(_serviceUrl, exchangeFormat);
            var route = "person";

            await httpService.DeleteAsync(route);
            var persons = await httpService.GetAsync<Person[]>(route);
            Assert.IsTrue(!persons.Any());

            var person = await httpService.PostAsync<Person>(route, new Person { FirstName = "Jean", LastName = "Némare" });
            persons = await httpService.GetAsync<Person[]>(route);
            Assert.IsTrue(persons.Any());
            Assert.IsTrue(person != null);

            person.LastName = "Népleinlecul";
            person = await httpService.PutAsync<Person>(route, person);
            persons = await httpService.GetAsync<Person[]>(route);
            Assert.IsTrue(persons.Any());
            Assert.IsTrue(person != null);

            await httpService.DeleteAsync($"{route}/{person.Id}");
            persons = await httpService.GetAsync<Person[]>(route);
            Assert.IsTrue(!persons.Any());
        }
    }

    public class Person
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
