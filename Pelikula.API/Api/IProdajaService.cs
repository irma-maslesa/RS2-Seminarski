using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Prodaja;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;

namespace Pelikula.API.Api
{
    public interface IProdajaService : ICrudService<ProdajaResponse, ProdajaInsertRequest, object>
    {
        PagedPayloadResponse<ProdajaResponse> GetForKorisnik(int korisnikId, PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting);
    }
}
