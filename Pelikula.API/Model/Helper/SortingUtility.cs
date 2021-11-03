using Pelikula.CORE.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Pelikula.API.Model.Helper
{
    public class SortingUtility
    {
        public enum SortOrders
        {
            ASC = 1,
            DESC = 2
        }

        public class SortingParams
        {
            public string SortOrder { get; set; } = string.Empty;
            public string ColumnName { get; set; } = string.Empty;
        }

        public static class Sorting<T>
        {
            public static IEnumerable<T> GroupingData(IEnumerable<T> data, IEnumerable<string> groupingColumns)
            {
                IOrderedEnumerable<T> groupedData = null;

                foreach (string grpCol in groupingColumns.Where(x => !String.IsNullOrEmpty(x)))
                {
                    var colName = typeof(T).GetProperty(grpCol, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (colName != null)
                    {
                        groupedData = groupedData == null ? data.OrderBy(x => colName.GetValue(x, null))
                                                        : groupedData.ThenBy(x => colName.GetValue(x, null));
                    }
                    else
                    {
                        throw new UserException($"Atribut {colName} ne postoji!", HttpStatusCode.BadRequest);
                    }
                }

                return groupedData ?? data;
            }
            public static IEnumerable<T> SortData(IEnumerable<SortingParams> sortingParams, IEnumerable<T> data)
            {
                ValidateSortingParams(sortingParams);
                IOrderedEnumerable<T> sortedData = null;
                foreach (var sortingParam in sortingParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)))
                {
                    SortOrders sortOrder;
                    try
                    {
                        sortOrder = (SortOrders)Enum.Parse(typeof(SortOrders), sortingParam.SortOrder.ToUpper());
                    }
                    catch (Exception)
                    {
                        throw new UserException($"Redoslijed {sortingParam.SortOrder} nije moguć!", HttpStatusCode.BadRequest);
                    }

                    var colName = typeof(T).GetProperty(sortingParam.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (colName != null)
                    {
                        sortedData = sortedData == null ? sortOrder == SortOrders.ASC ? data.OrderBy(x => colName.GetValue(x, null))
                                                                                                   : data.OrderByDescending(x => colName.GetValue(x, null))
                                                        : sortOrder == SortOrders.ASC ? sortedData.ThenBy(x => colName.GetValue(x, null))
                                                                                            : sortedData.ThenByDescending(x => colName.GetValue(x, null));
                    }
                    else
                    {
                        throw new UserException($"Atribut {colName} ne postoji!", HttpStatusCode.BadRequest);
                    }
                }
                return sortedData ?? data;
            }
        }

        private static void ValidateSortingParams(IEnumerable<SortingParams> sortingParams)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var sortingParam in sortingParams)
            {
                if (sortingParam.ColumnName.Equals(string.Empty) ||
                    sortingParam.SortOrder.Equals(string.Empty))
                {
                    stringBuilder.Append($"Fillter ({sortingParam.ColumnName} - {sortingParam.SortOrder}) nije ispravan! ");
                }
            }

            if (stringBuilder.ToString().Any())
            {
                throw new UserException(stringBuilder.ToString(), HttpStatusCode.BadRequest);

            }
        }

    }
}
