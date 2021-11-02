using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Helper.Response
{
    public class ValidationResponse : AbstractResponse
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string Description { get; set; }

        public ValidationResponse(HttpStatusCode statusCode, string description) : base(statusCode)
        {
            Description = description;
        }
    }
}
