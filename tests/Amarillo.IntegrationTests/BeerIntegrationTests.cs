using System.Linq;
using System.Net;
using NUnit.Framework;

namespace Amarillo.IntegrationTests
{
    public class BeerIntegrationTests : IntegrationTestsBase
    {
        [Test]
        public void ListBeersAsync_WithQuery_ReturnsBeers()
        {
            var searchTask = Amarillo.ListBeersAsync(query: "ale");
            searchTask.Wait();

            var payload = searchTask.Result.Payload;

            Assert.AreEqual(HttpStatusCode.OK, searchTask.Result.Status);
            Assert.NotNull(payload);
            Assert.Greater(payload.TotalBeers, 0);
            Assert.Greater(payload.TotalPages, 0);
            Assert.Greater(payload.CurrentPage, 0);
            Assert.Greater(payload.Beers.Count, 0);

            var firstBeer = payload.Beers.First();

            Assert.Greater(firstBeer.Id, 0);
            Assert.NotNull(firstBeer.Name);
            Assert.Greater(firstBeer.ABV, 0);
            Assert.NotNull(firstBeer.Brewery);

            Assert.Greater(firstBeer.Brewery.Id, 0);
            Assert.NotNull(firstBeer.Name);
        }

        [Test]
        public void GetBeerAsync_ValidId_ReturnsBeer()
        {
            int beerId = 17;

            var searchTask = Amarillo.GetBeerAsync(beerId);
            searchTask.Wait();

            var beer = searchTask.Result.Payload;

            Assert.AreEqual(HttpStatusCode.OK, searchTask.Result.Status);
            Assert.NotNull(beer);
            Assert.AreEqual(beerId, beer.Id);
            Assert.NotNull(beer.Name);
            Assert.Greater(beer.ABV, 0);
            Assert.NotNull(beer.Brewery);
        }
    }
}
