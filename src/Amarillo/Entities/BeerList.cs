using System.Collections.Generic;
using Amarillo.Entities;
using Newtonsoft.Json;

namespace Amarillo.Payloads
{
    public class BeerList
    {
        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        [JsonProperty("pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total")]
        public int TotalBeers { get; set; }

        public IList<Beer> Beers { get; set; }
    }
}
