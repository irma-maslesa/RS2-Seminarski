using Pelikula.API.Model;
using Pelikula.API.Model.Sala;
using Pelikula.CORE.Helper.Response;

namespace Pelikula.API.Api
{
    public interface ISalaService : ICrudService<SalaResponse, SalaUpsertRequest, SalaUpsertRequest>
    {
        ListPayloadResponse<LoV> GetZauzetaSjedista(int projekcijaTerminId);
        ListPayloadResponse<LoV> GetSjedista(int projekcijaId);
    }
}
