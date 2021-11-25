using Pelikula.API.Model.Artikal;

namespace Pelikula.API.Api
{
    public interface IArtikalService : ICrudService<ArtikalResponse, ArtikalUpsertRequest, ArtikalUpsertRequest>
    {
    }
}
