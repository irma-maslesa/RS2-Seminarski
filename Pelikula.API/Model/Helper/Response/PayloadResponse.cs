using System.Net;

namespace Pelikula.CORE.Helper.Response
{
    public class PayloadResponse<T> : AbstractResponse
        where T : class
    {
        public T Payload { get; set; }

        public PayloadResponse() : this(HttpStatusCode.InternalServerError, null) {
        }

        public PayloadResponse(HttpStatusCode statusCode, T payload) : base(statusCode) {
            Payload = payload;
        }
    }
}
