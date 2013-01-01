using System.Threading.Tasks;
using Amarillo.Entities;
using Amarillo.Network;
using Amarillo.Payloads;

namespace Amarillo
{
    public interface IAmarillo
    {
        Task<Response<BreweryList>> ListBreweriesAsync(string query = null, string orderBy = null, int? page = null, int? beersPerPage = null);
        Task<Response<Brewery>> GetBreweryAsync(int id);
        Task<Response<BeerList>> ListBeersAsync(string query = null, string orderBy = null, int? page = null, int? beersPerPage = null);
        Task<Response<Beer>> GetBeerAsync(int id);
    }
}