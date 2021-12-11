using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;

namespace Pelikula.API.Api
{
    public interface IReadService<ResponseDTO>
        where ResponseDTO : class
    {
        PagedPayloadResponse<ResponseDTO> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null);
        PagedPayloadResponse<LoV> GetLoVs(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null);

        PayloadResponse<ResponseDTO> GetById(int id);
    }
}
