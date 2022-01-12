using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Projekcija;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pelikula.API.Api
{
    public interface IProjekcijaService : ICrudService<ProjekcijaResponse, ProjekcijaUpsertRequest, ProjekcijaUpsertRequest>
    {
        PagedPayloadResponse<ProjekcijaResponse> GetActive(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting);
        
        PagedPayloadResponse<ProjekcijaDetailedResponse> GetDetailedActive(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting, string naziv, int? zanrId);

        Task<ListPayloadResponse<ProjekcijaResponse>> GetPreporucene(string korisnickoIme);

        PayloadResponse<string> PosjetiProjekciju(int projekcijaId, int korisnikId);

        ListPayloadResponse<LoV> GetTermine(int projekcijaId);

        ListPayloadResponse<LoV> GetAktivneTermine(int projekcijaId);

        ListPayloadResponse<LoV> GetAktivneTermineZaKorisnika(int projekcijaId, int korisnikId);

        PagedPayloadResponse<ProjekcijaDetailedResponse> GetDetailedComingSoon(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting, string naziv, int? zanrId);
    }
}
