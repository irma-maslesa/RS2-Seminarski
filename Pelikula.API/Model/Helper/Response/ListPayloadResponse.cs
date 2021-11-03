using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Helper.Response
{
    public class ListPayloadResponse<T> : AbstractResponse
        where T: class 
        
    {
        public IEnumerable<T> Payload { get; set; }

        public ListPayloadResponse(): this(HttpStatusCode.InternalServerError, new List<T>())
        {
        }

        public ListPayloadResponse(HttpStatusCode statusCode, IEnumerable<T> payload) : base(statusCode)
        {
            Payload = payload;
        }
    }
}
