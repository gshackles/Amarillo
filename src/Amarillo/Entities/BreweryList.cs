using System.Collections.Generic;
using Amarillo.Entities;
using Newtonsoft.Json;

namespace Amarillo.Payloads
{
    public class BreweryList
    {
        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        [JsonProperty("pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total")]
        public int TotalBreweries { get; set; }

        public IList<Brewery> Breweries { get; set; }
    }
}