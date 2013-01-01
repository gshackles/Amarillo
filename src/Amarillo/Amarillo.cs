using System;
using System.Collections.Generic;
using System.Linq;
using Amarillo.Network;

namespace Amarillo
{
    public partial class Amarillo : IAmarillo
    {
        private readonly string _apiToken;
        private readonly IRestClient _client;

        public Amarillo(string apiKey)
        {
            _apiToken = apiKey;
            _client = new JsonRestClient("http://api.openbeerdatabase.com/v1");
        }

        public Amarillo(string apiToken, IRestClient client)
        {
            _apiToken = apiToken;
            _client = client;
        }

        private string createUrl(string url, IDictionary<string, object> parameters = null)
        {
            if (!url.StartsWith("/"))
                url = "/" + url;

            if (parameters == null)
                parameters = new Dictionary<string, object>();

            parameters["token"] = _apiToken;

            string queryString = 
                string.Join("&",
                            parameters.Keys.Where(key => parameters[key] != null)
                                           .Select(key => key + "=" + Uri.EscapeUriString(parameters[key].ToString())));

            return url + "?" + queryString;
        }
    }
}
