using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amarillo.Network
{
    public class JsonRestClient : IRestClient
    {
        private readonly string _baseUrl;

        public JsonRestClient(string baseUrl)
        {
            _baseUrl = baseUrl;

            if (!_baseUrl.EndsWith("/"))
                _baseUrl += "/";
        }

        public Task<Response<TResponsePayload>> GetAsync<TResponsePayload>(string url)
        {
            return Task.Factory.StartNew(() => makeRequest<TResponsePayload>(url, "GET"));
        }

        public Task<Response<TResponsePayload>> PostAsync<TResponsePayload>(string url, object payload)
        {
            return Task.Factory.StartNew(() => makeRequest<TResponsePayload>(url, "POST", payload));
        }

        public Task<Response<TResponsePayload>> DeleteAsync<TResponsePayload>(string url)
        {
            return Task.Factory.StartNew(() => makeRequest<TResponsePayload>(url, "DELETE"));
        }

        public Task<Response<TResponsePayload>> PutAsync<TResponsePayload>(string url, object payload)
        {
            return Task.Factory.StartNew(() => makeRequest<TResponsePayload>(url, "PUT", payload));
        }

        private Response<TResponsePayload> makeRequest<TResponsePayload>(string url, string method,
                                                                         object payload = null)
        {
            Func<string, Response<TResponsePayload>> parseSuccessfulResponse =
                body =>
                new Response<TResponsePayload>
                    {
                        Status = HttpStatusCode.OK,
                        Payload = JsonConvert.DeserializeObject<TResponsePayload>(body)
                    };

            var uri = new Uri(_baseUrl + url);
            var client = new WebClient();

            try
            {
                return parseSuccessfulResponse(
                    method == "GET"
                        ? client.DownloadString(uri)
                        : client.UploadString(uri, method, JsonConvert.SerializeObject(payload)));
            }
            catch (WebException webEx)
            {
                var errorResponse = ((HttpWebResponse) webEx.Response);

                return new Response<TResponsePayload> {Status = errorResponse.StatusCode};

                // TODO: parse error list if there is one
            }
            catch (Exception)
            {
                return new Response<TResponsePayload> {Status = HttpStatusCode.InternalServerError};
            }
        }
    }
}