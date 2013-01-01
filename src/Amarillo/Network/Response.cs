using System.Collections.Generic;
using System.Net;

namespace Amarillo.Network
{
    public class Response<TPayload>
    {
        public HttpStatusCode Status { get; set; }
        public TPayload Payload { get; set; }
        public KeyValuePair<string, IList<string>> Errors { get; set; }
    }
}
