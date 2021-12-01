using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using Newtonsoft.Json;
using Pelikula.API.Model.Helper;
using System.Windows.Forms;
using Pelikula.CORE.Helper.Response;
using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.Projekcija;

namespace Pelikula.WINUI
{
    public class ApiService
    {
        private readonly string _route;

        public ApiService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(PaginationUtility.PaginationParams paginationParams, IEnumerable<FilterUtility.FilterParams> filterParams, IEnumerable<SortingUtility.SortingParams> sortingParams)
        {
            var queryParams = new
            {
                pagination = paginationParams != null ? JsonConvert.SerializeObject(paginationParams) : null,
                filter = filterParams != null && filterParams.Any() ? JsonConvert.SerializeObject(filterParams) : null,
                sorting = sortingParams != null && sortingParams.Any() ? JsonConvert.SerializeObject(sortingParams) : null
            };

            try
            {
                return await new Uri(Properties.Settings.Default.ApiURL)
                    .AppendPathSegment(_route)
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> GetLoVs<T>(PaginationUtility.PaginationParams paginationParams, IEnumerable<FilterUtility.FilterParams> filterParams, IEnumerable<SortingUtility.SortingParams> sortingParams)
        {
            var queryParams = new
            {
                pagination = paginationParams != null ? JsonConvert.SerializeObject(paginationParams) : null,
                filter = filterParams != null && filterParams.Any() ? JsonConvert.SerializeObject(filterParams) : null,
                sorting = sortingParams != null && sortingParams.Any() ? JsonConvert.SerializeObject(sortingParams) : null
            };

            try
            {
                return await new Uri(Properties.Settings.Default.ApiURL)
                    .AppendPathSegment(_route)
                    .AppendPathSegment("lov")
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> GetById<T>(int id)
        {
            try
            {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .PostJsonAsync(request)
                        .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .PutJsonAsync(request)
                        .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<PayloadResponse<string>> Delete(int id)
        {
            try
            {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .DeleteAsync()
                        .ReceiveJson<PayloadResponse<string>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<PayloadResponse<AnketaResponse>> ZatvoriAnketu(int id)
        {
            try
            {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .AppendPathSegment("zatvori")
                        .PutJsonAsync(null)
                        .ReceiveJson<PayloadResponse<AnketaResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<PagedPayloadResponse<ProjekcijaResponse>> GetAktivne(PaginationUtility.PaginationParams paginationParams, IEnumerable<FilterUtility.FilterParams> filterParams, IEnumerable<SortingUtility.SortingParams> sortingParams)
        {
            var queryParams = new
            {
                pagination = paginationParams != null ? JsonConvert.SerializeObject(paginationParams) : null,
                filter = filterParams != null && filterParams.Any() ? JsonConvert.SerializeObject(filterParams) : null,
                sorting = sortingParams != null && sortingParams.Any() ? JsonConvert.SerializeObject(sortingParams) : null
            };

            try
            {
                return await new Uri(Properties.Settings.Default.ApiURL)
                    .AppendPathSegment(_route)
                    .AppendPathSegment("aktivne")
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<PagedPayloadResponse<ProjekcijaResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

    }
}
