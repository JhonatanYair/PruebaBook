using System.Net;

namespace FrontendBook.Common
{
    public class ResponseApi
    {
        public HttpStatusCode CodeHttp { get; set; }
        public object Object { get; set; }
        public string Response { get; set; }
    }
}
