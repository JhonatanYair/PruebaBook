using System.Net;

namespace ApiBookTest.Common
{
    public class ResponseApi
    {
        public HttpStatusCode CodeHttp { get; set; }
        public object Object { get; set; }
        public string Response { get; set; }
    }
}
