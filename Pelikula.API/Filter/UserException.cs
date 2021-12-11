using System;
using System.Net;
using System.Runtime.Serialization;

namespace Pelikula.CORE.Filter
{
    [Serializable]
    public class UserException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public UserException(string message, HttpStatusCode statusCode) : base(message) {
            this.StatusCode = statusCode;
        }

        protected UserException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
