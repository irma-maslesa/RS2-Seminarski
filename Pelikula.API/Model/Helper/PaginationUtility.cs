using Pelikula.CORE.Filter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.API.Model.Helper
{
    public class PaginationUtility
    {
        public class PagedData<T> : IEnumerable<T> where T : class
        {
            public IEnumerable<T> Records { get; set; }
            public int RecordsPerPage { get; set; }
            public int Page { get; set; }
            public int NumberOfPages { get; set; }
            public int NumberOfRecords { get; set; }
            public bool HasMoreRecords { get; set; }

            public PagedData(IEnumerable<T> records, int recordsPerPage, int page,
                int numberOfPages, int numberOfRecords, bool hasMoreRecords = false) {
                Records = records;
                RecordsPerPage = recordsPerPage;
                Page = page;
                NumberOfPages = numberOfPages;
                NumberOfRecords = numberOfRecords;
                HasMoreRecords = hasMoreRecords;
            }

            public IEnumerator<T> GetEnumerator() {
                return Records.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return ((IEnumerable)Records).GetEnumerator();
            }
        }
        public class PaginationParams
        {
            public int Page { get; set; }
            public int RecordsPerPage { get; set; }
        }


        public static class Paginaion<T> where T : class
        {
            public static PagedData<T> PaginateData(IEnumerable<T> data, PaginationParams paginationParams = null) {
                if (paginationParams != null) {
                    ValidatePaginationParams(paginationParams);

                    List<T> records = data.Skip((paginationParams.Page - 1) * paginationParams.RecordsPerPage).Take(paginationParams.RecordsPerPage).ToList();
                    int numberOfPages = (int)Math.Ceiling(data.Count() / (paginationParams.RecordsPerPage * 1.0));
                    bool hasMoreRecords = data.Count() > paginationParams.Page * paginationParams.RecordsPerPage;
                    return new PagedData<T>(records, paginationParams.RecordsPerPage, paginationParams.Page, numberOfPages, data.Count(), hasMoreRecords);
                }
                else {
                    return new PagedData<T>(data, data.Count(), 1, 1, data.Count());

                }
            }

            private static void ValidatePaginationParams(PaginationParams paginationParams) {
                if (paginationParams.Page < 1 || paginationParams.RecordsPerPage < 1) {
                    throw new UserException("Paginacija nije ispravna!", HttpStatusCode.BadRequest);
                }
            }
        }
    }

}
