using Pelikula.API.Model.Obavijest;

namespace Pelikula.API.Api
{
    public interface IObavijestService : ICrudService<ObavijestResponse, ObavijestUpsertRequest, ObavijestUpsertRequest>
    {
    }
}
