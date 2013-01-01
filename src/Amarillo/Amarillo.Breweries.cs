using System.Collections.Generic;
using System.Threading.Tasks;
using Amarillo.Entities;
using Amarillo.Network;
using Amarillo.Payloads;

namespace Amarillo
{
    public partial class Amarillo
    {
        public Task<Response<BreweryList>> ListBreweriesAsync(string query = null, string orderBy = null, int? page = null, int? beersPerPage = null)
        {
            var url = createUrl("/breweries.json", new Dictionary<string, object>
                                                   {
                                                       { "query", query },
                                                       { "order", orderBy },
                                                       { "page", page },
                                                       { "per_page", beersPerPage }
                                                   });

            return _client.GetAsync<BreweryList>(url);
        }

        public Task<Response<Brewery>> GetBreweryAsync(int id)
        {
            var url = createUrl("/breweries/" + id + ".json");

            return _client.GetAsync<Brewery>(url);
        }
    }
}
