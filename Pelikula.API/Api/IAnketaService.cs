using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;

namespace Pelikula.API.Api
{
    public interface IAnketaService : ICrudService<AnketaResponse, AnketaInsertRequest, AnketaUpdateRequest>
    {
        PayloadResponse<AnketaExtendedResponse> InsertKorisnikOdgovor(AnketaOdgovorKorisnikInsertRequest request);
        PayloadResponse<AnketaResponse> Close(int id);
        PagedPayloadResponse<AnketaResponse> GetActive(int? korisnikId, PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting);
        PagedPayloadResponse<AnketaExtendedResponse> GetForUser(int korisnikId, PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting);
    }
}
