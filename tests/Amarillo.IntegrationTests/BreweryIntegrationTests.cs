using System.Linq;
using System.Net;
using NUnit.Framework;

namespace Amarillo.IntegrationTests
{
    public class BreweryIntegrationTests : IntegrationTestsBase
    {
        [Test]
        public void ListBreweriesAsync_WithQuery_ReturnsBreweries()
        {
            var searchTask = Client.ListBreweriesAsync(query: "ab");
            searchTask.Wait();

            var payload = searchTask.Result.Payload;

            Assert.AreEqual(HttpStatusCode.OK, searchTask.Result.Status);
            Assert.NotNull(payload);
            Assert.AreNotEqual(0, payload.TotalBreweries);
            Assert.AreNotEqual(0, payload.TotalPages);
            Assert.AreNotEqual(0, payload.CurrentPage);
            Assert.AreNotEqual(0, payload.Breweries.Count);

            var firstBrewery = payload.Breweries.First();

            Assert.AreNotEqual(0, firstBrewery.Id);
            Assert.NotNull(firstBrewery.Name);
        }

        [Test]
        public void GetBreweryAsync_ValidId_ReturnsBrewery()
        {
            int breweryId = 4;

            var searchTask = Client.GetBreweryAsync(breweryId);
            searchTask.Wait();

            var brewery = searchTask.Result.Payload;
            Assert.AreEqual(HttpStatusCode.OK, searchTask.Result.Status);
            Assert.NotNull(brewery);
            Assert.AreEqual(breweryId, brewery.Id);
            Assert.NotNull(brewery.Name);
        }
    }
}