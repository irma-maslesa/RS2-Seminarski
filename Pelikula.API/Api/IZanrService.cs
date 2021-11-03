using Pelikula.API.Model.Zanr;

namespace Pelikula.API.Api
{
    public interface IZanrService : ICrudService<ZanrResponse, ZanrSearchRequest, ZanrUpsertRequest, ZanrUpsertRequest>
    {
    }
}
