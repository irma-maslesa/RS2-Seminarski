using System.Net;

namespace Pelikula.CORE.Helper.Response
{
    public abstract class AbstractResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseDetail { get; set; }

        protected AbstractResponse(HttpStatusCode responseCode) {
            ResponseCode = (int)responseCode;
            ResponseDetail = responseCode.ToString();
        }

        public bool IsSuccessfull() {
            return ResponseCode.ToString().Substring(0, 1) == "2";
        }
    }
}
