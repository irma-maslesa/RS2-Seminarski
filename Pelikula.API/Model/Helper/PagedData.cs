using System;
using System.Collections.Generic;
using System.Text;

namespace Pelikula.CORE.Helper
{
    public class PagedData<T> where T:class
    {
        public IEnumerable<T> Records { get; set; }
        public int RecordsPerPage { get; set; }
        public int Page { get; set; }
        public int NumberOfPages { get; set; }
        public int NumberOfRecords { get; set; }
        public bool HasMoreRecords { get; set; }

        public PagedData(IEnumerable<T> records, int recordsPerPage, int page,
            int numberOfPages, int numberOfRecords, bool hasMoreRecords = false)
        {
            Records = records;
            RecordsPerPage = recordsPerPage;
            Page = page;
            NumberOfPages = numberOfPages;
            NumberOfRecords = numberOfRecords;
            HasMoreRecords = hasMoreRecords;
        }
    }
}
