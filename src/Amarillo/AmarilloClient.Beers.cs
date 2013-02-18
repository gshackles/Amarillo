using System.Collections.Generic;
using System.Threading.Tasks;
using Amarillo.Entities;
using Amarillo.Network;
using Amarillo.Payloads;

namespace Amarillo
{
    public partial class AmarilloClient
    {
        public Task<Response<BeerList>> ListBeersAsync(string query = null, string orderBy = null, int? page = null, int? beersPerPage = null)
        {
            var url = createUrl("/beers.json", new Dictionary<string, object>
                                                   {
                                                       { "query", query },
                                                       { "order", orderBy },
                                                       { "page", page },
                                                       { "per_page", beersPerPage }
                                                   });

            return _client.GetAsync<BeerList>(url);
        }

        public Task<Response<Beer>> GetBeerAsync(int id)
        {
            var url = createUrl("/beers/" + id + ".json");

            return _client.GetAsync<Beer>(url);
        }
    }
}
