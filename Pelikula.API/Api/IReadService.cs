using Pelikula.API.Model.Helper;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;

namespace Pelikula.API.Api
{
    public interface IReadService<ResponseDTO, in SearchDTO>
        where ResponseDTO : class
        where SearchDTO : class
    {
        ListPayloadResponse<ResponseDTO> Get( IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null);

        PagedPayloadResponse<ResponseDTO> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null);
        PayloadResponse<ResponseDTO> GetById(int id);
    }
}
