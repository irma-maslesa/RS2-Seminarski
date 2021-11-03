using Pelikula.CORE.Helper.Response;

namespace Pelikula.API.Api
{
    public interface IReadService<ResponseDTO, in SearchDTO>
        where ResponseDTO : class
        where SearchDTO : class
    {
        ListPayloadResponse<ResponseDTO> Get(SearchDTO search = null);
        PayloadResponse<ResponseDTO> GetById(int id);
    }
}
