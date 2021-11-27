using Pelikula.API.Model.Sala;

namespace Pelikula.API.Api
{
    public interface ISalaService : ICrudService<SalaResponse, SalaUpsertRequest, SalaUpsertRequest>
    {
    }
}
