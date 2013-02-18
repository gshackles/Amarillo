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
            var searchTask = Client.ListBeersAsync(query: "ale");
            searchTask.Wait();

            var payload = searchTask.Result.Payload;

            Assert.AreEqual(HttpStatusCode.OK, searchTask.Result.Status);
            Assert.NotNull(payload);
            Assert.AreNotEqual(0, payload.TotalBeers);
            Assert.AreNotEqual(0, payload.TotalPages);
            Assert.AreNotEqual(0, payload.CurrentPage);
            Assert.AreNotEqual(0, payload.Beers.Count);

            var firstBeer = payload.Beers.First();

            Assert.AreNotEqual(0, firstBeer.Id);
            Assert.NotNull(firstBeer.Name);
            Assert.AreNotEqual(0, firstBeer.ABV);
            Assert.NotNull(firstBeer.Brewery);

            Assert.AreNotEqual(0, firstBeer.Brewery.Id);
            Assert.NotNull(firstBeer.Name);
        }

        [Test]
        public void GetBeerAsync_ValidId_ReturnsBeer()
        {
            int beerId = 17;

            var searchTask = Client.GetBeerAsync(beerId);
            searchTask.Wait();

            var beer = searchTask.Result.Payload;

            Assert.AreEqual(HttpStatusCode.OK, searchTask.Result.Status);
            Assert.NotNull(beer);
            Assert.AreEqual(beerId, beer.Id);
            Assert.NotNull(beer.Name);
            Assert.AreNotEqual(0, beer.ABV);
            Assert.NotNull(beer.Brewery);
        }
    }
}
