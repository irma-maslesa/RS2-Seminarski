using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Pelikula.API.Model;
using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Izvjestaj;
using Pelikula.API.Model.Korisnik;
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

        private readonly KorisnikResponse _prijavljeniKorisnik;

        public ApiService(string route) {
            _route = route;
            _prijavljeniKorisnik = Properties.Settings.Default.PrijavljeniKorisnik;
        }

        private static T HandleException<T>(Dictionary<string, string> errors) {
            if (errors != null) {
                errors.TryGetValue("message", out string message);

                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Došlo je do greške", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return default;
        }

        public async Task<PayloadResponse<KorisnikResponse>> Prijava(string korisnickoIme, string lozinka) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment("autentifikacija")
                        .WithBasicAuth(korisnickoIme, lozinka)
                        .GetJsonAsync<PayloadResponse<KorisnikResponse>>();
            }
            catch (FlurlHttpException ex) {
                if (ex.StatusCode == 401)
                    MessageBox.Show("Neispravno korisničko ime ili lozinka! ", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Došlo je do greške, pokušajte opet! ", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return default;
            }
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
                    .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<T>(errors);
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
                    .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<T>(errors);
            }
        }

        public async Task<T> GetById<T>(int id) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<T>(errors);
            }
        }

        public async Task<T> Insert<T>(object request) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .PostJsonAsync(request)
                        .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<T>(errors);
            }
        }

        public async Task<T> Update<T>(int id, object request) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .PutJsonAsync(request)
                        .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<T>(errors);
            }
        }

        public async Task<PayloadResponse<string>> Delete(int id) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .DeleteAsync()
                        .ReceiveJson<PayloadResponse<string>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<PayloadResponse<string>>(errors);
            }
        }

        public async Task<PayloadResponse<AnketaResponse>> ZatvoriAnketu(int id) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .AppendPathSegment("zatvori")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .PutJsonAsync(null)
                        .ReceiveJson<PayloadResponse<AnketaResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<PayloadResponse<AnketaResponse>>(errors);
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
                    .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<PagedPayloadResponse<ProjekcijaResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<PagedPayloadResponse<ProjekcijaResponse>>(errors);
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetTermini(int projekcijaId) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaId)
                        .AppendPathSegment("termini")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<LoV>>(errors);
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetAktivniTermini(int projekcijaId) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaId)
                        .AppendPathSegment("aktivni-termini")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<LoV>>(errors);
            }
        }

        public async Task<PayloadResponse<RezervacijaResponse>> OtkaziRezervaciju(int id) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(id)
                        .AppendPathSegment("otkazi")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .PutJsonAsync(null)
                        .ReceiveJson<PayloadResponse<RezervacijaResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<PayloadResponse<RezervacijaResponse>>(errors);
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetSjedista(int projekcijaId) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaId)
                        .AppendPathSegment("sjedista")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<LoV>>(errors);
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetZauzetaSjedista(int projekcijaTerminId) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaTerminId)
                        .AppendPathSegment("zauzeta-sjedista")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<LoV>>(errors);
            }
        }

        public async Task<ListPayloadResponse<LoV>> GetKlijentiForTermin(int projekcijaTerminId, bool bezRezervacije) {
            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment(projekcijaTerminId)
                        .AppendPathSegment(bezRezervacije)
                        .AppendPathSegment("klijenti")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .GetJsonAsync<ListPayloadResponse<LoV>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<LoV>>(errors);
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
                    .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<PagedPayloadResponse<RezervacijaSimpleResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<PagedPayloadResponse<RezervacijaSimpleResponse>>(errors);
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
                        .AppendPathSegment("prodaja")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .SetQueryParams(queryParams)
                        .GetJsonAsync<ListPayloadResponse<IzvjestajProdajaPoDatumuResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<IzvjestajProdajaPoDatumuResponse>>(errors);
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
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .SetQueryParams(queryParams)
                        .GetJsonAsync<ListPayloadResponse<IzvjestajPrometUGodiniResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<IzvjestajPrometUGodiniResponse>>(errors);
            }
        }

        public async Task<ListPayloadResponse<IzvjestajOdnosOnlineInstore>> GetOdnosOnlineInstore(DateTime? datumOd, DateTime? datumDo) {

            var queryParams = new {
                datumOd,
                datumDo
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment("odnos")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .SetQueryParams(queryParams)
                        .GetJsonAsync<ListPayloadResponse<IzvjestajOdnosOnlineInstore>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<IzvjestajOdnosOnlineInstore>>(errors);
            }
        }

        public async Task<ListPayloadResponse<IzvjestajTopKorisnici>> GetTopKorisnici(int brojKorisnika, int? zanrId) {

            var queryParams = new {
                brojKorisnika,
                zanrId,
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                        .AppendPathSegment(_route)
                        .AppendPathSegment("top-korisnici")
                        .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                        .SetQueryParams(queryParams)
                        .GetJsonAsync<ListPayloadResponse<IzvjestajTopKorisnici>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<ListPayloadResponse<IzvjestajTopKorisnici>>(errors);
            }
        }

        public async Task<PagedPayloadResponse<RezervacijaResponse>> GetRezervacijaNotProdaja(PaginationUtility.PaginationParams paginationParams, IEnumerable<FilterUtility.FilterParams> filterParams, IEnumerable<SortingUtility.SortingParams> sortingParams) {
            var queryParams = new {
                pagination = paginationParams != null ? JsonConvert.SerializeObject(paginationParams) : null,
                filter = filterParams != null && filterParams.Any() ? JsonConvert.SerializeObject(filterParams) : null,
                sorting = sortingParams != null && sortingParams.Any() ? JsonConvert.SerializeObject(sortingParams) : null
            };

            try {
                return await new Uri(Properties.Settings.Default.ApiURL)
                    .AppendPathSegment(_route)
                    .AppendPathSegment("not-prodaja")
                    .WithBasicAuth(_prijavljeniKorisnik?.KorisnickoIme, _prijavljeniKorisnik?.Lozinka)
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<PagedPayloadResponse<RezervacijaResponse>>();
            }
            catch (FlurlHttpException ex) {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string>>();

                return HandleException<PagedPayloadResponse<RezervacijaResponse>>(errors);
            }
        }

    }
}
