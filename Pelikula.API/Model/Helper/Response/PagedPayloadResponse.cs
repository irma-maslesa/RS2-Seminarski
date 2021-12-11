using Pelikula.API.Model.Helper;
using System.Collections.Generic;
using System.Net;

namespace Pelikula.CORE.Helper.Response
{
    public class PagedPayloadResponse<T> : AbstractResponse
        where T : class

    {
        public IEnumerable<T> Payload { get; set; }
        public int RecordsPerPage { get; set; }
        public int Page { get; set; }
        public int NumberOfPages { get; set; }
        public int NumberOfRecords { get; set; }

        public PagedPayloadResponse() : base(HttpStatusCode.InternalServerError) {
            Payload = new List<T>();
            RecordsPerPage = -1;
            Page = -1;
            NumberOfPages = -1;
            NumberOfRecords = -1;
        }

        public PagedPayloadResponse(HttpStatusCode statusCode, int recordsPerPage, int page,
            int numberOfPages, int numberOfRecords, IEnumerable<T> payload) : base(statusCode) {
            Payload = payload;
            RecordsPerPage = recordsPerPage;
            Page = page;
            NumberOfPages = numberOfPages;
            NumberOfRecords = numberOfRecords;
        }

        public PagedPayloadResponse(HttpStatusCode statusCode, PaginationUtility.PagedData<T> pagedData) :
            this(statusCode, pagedData.RecordsPerPage, pagedData.Page, pagedData.NumberOfPages,
                pagedData.NumberOfRecords, pagedData.Records) {
        }
    }
}
