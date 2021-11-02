using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Helper.Response
{
    public class AbstractResponse
    {
        private int ResponseCode { get; set; }
        private string ResponseDetail { get; set; }

        protected AbstractResponse(HttpStatusCode responseCode)
        {
            ResponseCode = (int)responseCode;
            ResponseDetail = responseCode.ToString();
        }

        public bool IsSuccessfull()
        {
            return ResponseCode.ToString().Substring(0, 1) == "2";
        }
    }
}
