using System;
using System.Collections.Generic;
using System.Text;

namespace Pelikula.API.Model.Helper
{
    public class FilterModel
    {
        public IEnumerable<FilterUtility.FilterParams> Filter { get; set; }
        public IEnumerable<SortingUtility.SortingParams> Sorting { get; set; }
        public PaginationUtility.PaginationParams Pagination { get; set; }
    }
}
