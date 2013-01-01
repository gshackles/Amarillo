using System.Threading.Tasks;

namespace Amarillo.Network
{
    public interface IRestClient
    {
        Task<Response<TResponsePayload>> GetAsync<TResponsePayload>(string url);
        Task<Response<TResponsePayload>> PostAsync<TResponsePayload>(string url, object payload);
        Task<Response<TResponsePayload>> DeleteAsync<TResponsePayload>(string url);
        Task<Response<TResponsePayload>> PutAsync<TResponsePayload>(string url, object payload);
    }
}