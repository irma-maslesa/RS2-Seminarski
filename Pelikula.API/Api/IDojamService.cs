using Pelikula.API.Model.Dojam;
using Pelikula.CORE.Helper.Response;

namespace Pelikula.API.Api
{
    public interface IDojamService : ICrudService<DojamResponse, DojamUpsertRequest, DojamUpsertRequest>
    {
        PayloadResponse<DojamResponse> GetByProjekcijaKorisnik(int projekcijaId, int korisnikId);
    }
}
