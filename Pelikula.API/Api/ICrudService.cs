using Pelikula.CORE.Helper.Response;

namespace Pelikula.API.Api
{
    public interface ICrudService<ResponseDTO, InsertDTO, UpdateDTO> : IReadService<ResponseDTO>
        where ResponseDTO : class
        where InsertDTO : class
        where UpdateDTO : class
    {
        PayloadResponse<ResponseDTO> Insert(InsertDTO request);
        PayloadResponse<ResponseDTO> Update(int id, UpdateDTO request);
        PayloadResponse<string> Delete(int id);
    }
}
