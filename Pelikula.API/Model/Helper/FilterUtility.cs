using Pelikula.CORE.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Pelikula.API.Model.Helper
{
    public class FilterUtility
    {
        public enum FilterOptions
        {
            startswith = 1,
            endswith,
            contains,
            doesnotcontain,
            isempty,
            isnotempty,
            isgreaterthan,
            isgreaterthanorequalto,
            islessthan,
            islessthanorequalto,
            isequalto,
            isnotequalto
        }

        public class FilterParams
        {
            public string ColumnName { get; set; } = string.Empty;
            public string FilterValue { get; set; } = string.Empty;
            public string FilterOption { get; set; } = string.Empty;

            public FilterParams()
            {
            }

            public FilterParams(string columnName, string filterValue, string filterOption)
            {
                ColumnName = columnName;
                FilterValue = filterValue;
                FilterOption = filterOption;
            }
        }

        public static class Filter<T>
        {
            public static IEnumerable<T> FilteredData(IEnumerable<FilterParams> filterParams, IEnumerable<T> data)
            {
                ValidateFilterParams(filterParams);

                IEnumerable<string> distinctColumns = filterParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)).Select(x => x.ColumnName).Distinct();

                foreach (string colName in distinctColumns)
                {

                    var filterColumn = typeof(T).GetProperty(colName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (filterColumn != null)
                    {
                        IEnumerable<FilterParams> filterValues = filterParams.Where(x => x.ColumnName.Equals(colName));
                        if (filterValues.Count() > 1)
                        {
                            List<IEnumerable<T>> sameColData = new List<IEnumerable<T>>();

                            foreach (var val in filterValues)
                            {
                                sameColData.Add(FilterData(val.FilterOption, data, filterColumn, val.FilterValue));
                            }

                            data = sameColData.Aggregate((a, b) => a.Intersect(b));
                        }
                        else
                        {
                            data = FilterData(filterValues.FirstOrDefault().FilterOption, data, filterColumn, filterValues.FirstOrDefault().FilterValue);
                        }
                    }
                    else
                    {
                        throw new UserException($"Atribut {colName} ne postoji!", HttpStatusCode.BadRequest);
                    }
                }
                return data;
            }
            private static IEnumerable<T> FilterData(string option, IEnumerable<T> data, PropertyInfo filterColumn, string filterValue)
            {

                FilterOptions filterOption;
                try
                {
                    filterOption = (FilterOptions)Enum.Parse(typeof(FilterOptions), option.ToLower());
                }
                catch (Exception)
                {
                    throw new UserException($"Operacija {option} nije moguća!", HttpStatusCode.BadRequest);
                }

                int outValue;
                DateTime dateValue;
                switch (filterOption)
                {
                    #region [StringDataType]  

                    case FilterOptions.startswith:
                        data = data.Where(x => filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString().ToLower().StartsWith(filterValue.ToString().ToLower())).ToList();
                        break;
                    case FilterOptions.endswith:
                        data = data.Where(x => filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString().ToLower().EndsWith(filterValue.ToString().ToLower())).ToList();
                        break;
                    case FilterOptions.contains:
                        data = data.Where(x => filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString().ToLower().Contains(filterValue.ToString().ToLower())).ToList();
                        break;
                    case FilterOptions.doesnotcontain:
                        data = data.Where(x => filterColumn.GetValue(x, null) == null ||
                                         (filterColumn.GetValue(x, null) != null && !filterColumn.GetValue(x, null).ToString().ToLower().Contains(filterValue.ToString().ToLower()))).ToList();
                        break;
                    case FilterOptions.isempty:
                        data = data.Where(x => filterColumn.GetValue(x, null) == null ||
                                         (filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString() == string.Empty)).ToList();
                        break;
                    case FilterOptions.isnotempty:
                        data = data.Where(x => filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString() != string.Empty).ToList();
                        break;
                    #endregion

                    #region [Custom]  

                    case FilterOptions.isgreaterthan:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out outValue))
                        {
                            data = data.Where(x => Convert.ToInt32(filterColumn.GetValue(x, null)) > outValue).ToList();
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) > dateValue).ToList();

                        }
                        else if ((filterColumn.PropertyType == typeof(DateTime)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) > dateValue).ToList();
                            break;
                        }
                        break;

                    case FilterOptions.isgreaterthanorequalto:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out outValue))
                        {
                            data = data.Where(x => Convert.ToInt32(filterColumn.GetValue(x, null)) >= outValue).ToList();
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) >= dateValue).ToList();
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(DateTime)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) >= dateValue).ToList();
                            break;
                        }
                        break;

                    case FilterOptions.islessthan:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out outValue))
                        {
                            data = data.Where(x => Convert.ToInt32(filterColumn.GetValue(x, null)) < outValue).ToList();
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) < dateValue).ToList();
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(DateTime)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) < dateValue).ToList();
                            break;
                        }
                        break;

                    case FilterOptions.islessthanorequalto:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out outValue))
                        {
                            data = data.Where(x => Convert.ToInt32(filterColumn.GetValue(x, null)) <= outValue).ToList();
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) <= dateValue).ToList();
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(DateTime)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) <= dateValue).ToList();
                            break;
                        }
                        break;

                    case FilterOptions.isequalto:
                        if (filterValue == string.Empty)
                        {
                            data = data.Where(x => filterColumn.GetValue(x, null) == null
                                            || (filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString().ToLower() == string.Empty)).ToList();
                        }
                        else
                        {
                            if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out outValue))
                            {
                                data = data.Where(x => Convert.ToInt32(filterColumn.GetValue(x, null)) == outValue).ToList();
                            }
                            else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && (DateTime.TryParse(filterValue, out dateValue) || filterValue == null))
                            {
                                data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) == dateValue).ToList();
                                break;
                            }
                            else if ((filterColumn.PropertyType == typeof(DateTime)) && DateTime.TryParse(filterValue, out dateValue))
                            {
                                data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) == dateValue).ToList();
                                break;
                            }
                            else
                            {
                                data = data.Where(x => filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString().ToLower() == filterValue.ToLower()).ToList();
                            }
                        }
                        break;

                    case FilterOptions.isnotequalto:
                        if ((filterColumn.PropertyType == typeof(Int32) || filterColumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out outValue))
                        {
                            data = data.Where(x => Convert.ToInt32(filterColumn.GetValue(x, null)) != outValue).ToList();
                        }
                        else if ((filterColumn.PropertyType == typeof(Nullable<DateTime>)) && (DateTime.TryParse(filterValue, out dateValue) || filterValue == null))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) != dateValue).ToList();
                            break;
                        }
                        else if ((filterColumn.PropertyType == typeof(DateTime)) && DateTime.TryParse(filterValue, out dateValue))
                        {
                            data = data.Where(x => Convert.ToDateTime(filterColumn.GetValue(x, null)) == dateValue).ToList();
                            break;
                        }
                        else
                        {
                            data = data.Where(x => filterColumn.GetValue(x, null) == null ||
                                             (filterColumn.GetValue(x, null) != null && filterColumn.GetValue(x, null).ToString().ToLower() != filterValue.ToLower())).ToList();
                        }
                        break;
                        #endregion
                }
                return data;
            }
        }

        private static void ValidateFilterParams(IEnumerable<FilterParams> filterParams)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var filterParam in filterParams)
            {
                if (filterParam.ColumnName.Equals(string.Empty) ||
                    (filterParam.FilterValue != null && filterParam.FilterValue.Equals(string.Empty)) ||
                    filterParam.FilterOption.Equals(string.Empty))
                {
                    stringBuilder.Append($"Fillter ({filterParam.ColumnName} - {filterParam.FilterValue} - {filterParam.FilterOption}) nije ispravan! ");
                }
            }

            if (stringBuilder.ToString().Any())
            {
                throw new UserException(stringBuilder.ToString(), HttpStatusCode.BadRequest);

            }
        }
    }
}
