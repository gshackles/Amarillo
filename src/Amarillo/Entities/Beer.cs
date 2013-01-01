using System;
using Newtonsoft.Json;

namespace Amarillo.Entities
{
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float ABV { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public Brewery Brewery { get; set; }
    }
}