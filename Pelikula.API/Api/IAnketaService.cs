using Pelikula.API.Model.Anketa;

namespace Pelikula.API.Api
{
    public interface IAnketaService : ICrudService<AnketaResponse, AnketaInsertRequest, AnketaUpdateRequest>
    {
    }
}
