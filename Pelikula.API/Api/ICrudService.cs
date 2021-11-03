using Pelikula.CORE.Helper.Response;

namespace Pelikula.API.Api
{
    public interface ICrudService<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO> : IReadService<ResponseDTO, SearchDTO>
        where ResponseDTO : class
        where SearchDTO : class
        where InsertDTO : class
        where UpdateDTO : class
    {
        PayloadResponse<ResponseDTO> Insert(InsertDTO request);
        PayloadResponse<ResponseDTO> Update(int id, UpdateDTO request);
        PayloadResponse<string> Delete(int id);
    }
}
