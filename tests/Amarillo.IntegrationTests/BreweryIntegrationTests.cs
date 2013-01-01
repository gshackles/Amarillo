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
            var searchTask = Amarillo.ListBreweriesAsync(query: "ab");
            searchTask.Wait();

            var payload = searchTask.Result.Payload;

            Assert.AreEqual(HttpStatusCode.OK, searchTask.Result.Status);
            Assert.NotNull(payload);
            Assert.Greater(payload.TotalBreweries, 0);
            Assert.Greater(payload.TotalPages, 0);
            Assert.Greater(payload.CurrentPage, 0);
            Assert.Greater(payload.Breweries.Count, 0);

            var firstBrewery = payload.Breweries.First();

            Assert.Greater(firstBrewery.Id, 0);
            Assert.NotNull(firstBrewery.Name);
        }

        [Test]
        public void GetBreweryAsync_ValidId_ReturnsBrewery()
        {
            int breweryId = 4;

            var searchTask = Amarillo.GetBreweryAsync(breweryId);
            searchTask.Wait();

            var brewery = searchTask.Result.Payload;
            Assert.AreEqual(HttpStatusCode.OK, searchTask.Result.Status);
            Assert.NotNull(brewery);
            Assert.AreEqual(breweryId, brewery.Id);
            Assert.NotNull(brewery.Name);
        }
    }
}