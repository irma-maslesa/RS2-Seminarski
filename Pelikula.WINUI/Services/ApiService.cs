using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Pelikula.API.Model;
using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Izvjestaj;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI
{
    public class ApiService
    {
        private readonly string _route;

        public ApiService(string route) {
            _route = route;
        }

        public async Task<T> Get<T>(PaginationUtility.PaginationParams paginationParams, IEnumerable<FilterUtility.FilterParams> filterParams, IEnumerable<SortingUtility.SortingParams> sortingParams) {
            var queryParams = new {
                pagination = paginationParams != null ? JsonConvert.SerializeObject(paginationParams) : null,
                filter = filterParams != null && filterParams.Any() ? JsonConvert.SerializeObject(filterParams) : null,
                sorting = sortingParams != null && sortingParams.Any() ? JsonConvert.SerializeObject(sortingParams) : null
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                    .AppendPathSegment(_route)
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> GetLoVs<T>(PaginationUtility.PaginationParams paginationParams, IEnumerable<FilterUtility.FilterParams> filterParams, IEnumerable<SortingUtility.SortingParams> sortingParams) {
            var queryParams = new {
                pagination = paginationParams != null ? JsonConvert.SerializeObject(paginationParams) : null,
                filter = filterParams != null && filterParams.Any() ? JsonConvert.SerializeObject(filterParams) : null,
                sorting = sortingParams != null && sortingParams.Any() ? JsonConvert.SerializeObject(sortingParams) : null
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                    .AppendPathSegment(_route)
                    .AppendPathSegment("lov")
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> GetById<T>(int id) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> Insert<T>(object request) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .PostJsonAsync(request)
                        .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> Update<T>(int id, object request) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .PutJsonAsync(request)
                        .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<PayloadResponse<string>> Delete(int id) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .DeleteAsync()
                        .ReceiveJson<PayloadResponse<string>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<PayloadResponse<AnketaResponse>> ZatvoriAnketu(int id) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .AppendPathSegment("zatvori")
                        .PutJsonAsync(null)
                        .ReceiveJson<PayloadResponse<AnketaResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<PagedPayloadResponse<ProjekcijaResponse>> GetAktivne(PaginationUtility.PaginationParams paginationParams, IEnumerable<FilterUtility.FilterParams> filterParams, IEnumerable<SortingUtility.SortingParams> sortingParams) {
            var queryParams = new {
                pagination = paginationParams != null ? JsonConvert.SerializeObject(paginationParams) : null,
                filter = filterParams != null && filterParams.Any() ? JsonConvert.SerializeObject(filterParams) : null,
                sorting = sortingParams != null && sortingParams.Any() ? JsonConvert.SerializeObject(sortingParams) : null
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                    .AppendPathSegment(_route)
                    .AppendPathSegment("aktivne")
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<PagedPayloadResponse<ProjekcijaResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetTermini(int projekcijaId) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaId)
                        .AppendPathSegment("termini")
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetAktivniTermini(int projekcijaId) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaId)
                        .AppendPathSegment("aktivni-termini")
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<PayloadResponse<RezervacijaResponse>> OtkaziRezervaciju(int id) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .AppendPathSegment("otkazi")
                        .PutJsonAsync(null)
                        .ReceiveJson<PayloadResponse<RezervacijaResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetSjedista(int projekcijaId) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaId)
                        .AppendPathSegment("sjedista")
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetZauzetaSjedista(int projekcijaTerminId) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaTerminId)
                        .AppendPathSegment("zauzeta-sjedista")
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetKlijentiForTermin(int projekcijaTerminId, bool bezRezervacije) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaTerminId)
                        .AppendPathSegment(bezRezervacije)
                        .AppendPathSegment("klijenti")
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<PagedPayloadResponse<RezervacijaSimpleResponse>> GetSimple(PaginationUtility.PaginationParams paginationParams, IEnumerable<FilterUtility.FilterParams> filterParams, IEnumerable<SortingUtility.SortingParams> sortingParams) {
            var queryParams = new {
                pagination = paginationParams != null ? JsonConvert.SerializeObject(paginationParams) : null,
                filter = filterParams != null && filterParams.Any() ? JsonConvert.SerializeObject(filterParams) : null,
                sorting = sortingParams != null && sortingParams.Any() ? JsonConvert.SerializeObject(sortingParams) : null
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                    .AppendPathSegment(_route)
                    .AppendPathSegment("simple")
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<PagedPayloadResponse<RezervacijaSimpleResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<ListPayloadResponse<IzvjestajProdajaPoDatumuResponse>> GetProdajaPoDatumu(DateTime datumOd, DateTime datumDo) {

            var queryParams = new {
                datumOd,
                datumDo
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .SetQueryParams(queryParams)
                        .GetJsonAsync<ListPayloadResponse<IzvjestajProdajaPoDatumuResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<ListPayloadResponse<IzvjestajPrometUGodiniResponse>> GetPrometUGodini(int? zanrId) {

            var queryParams = new {
                zanrId,
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment("promet")
                        .SetQueryParams(queryParams)
                        .GetJsonAsync<ListPayloadResponse<IzvjestajPrometUGodiniResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }


    }
}
