using AutoMapper;
using Pelikula.API.Api;
using Pelikula.API.Model.TipKorisnika;
using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Impl
{
    public class TipKorisnikaServiceImpl :
        CrudServiceImpl<TipKorisnikaResponse, TipKorisnika, TipKorisnikaUpsertRequest, TipKorisnikaUpsertRequest>,
        ITipKorisnikaService
    {
        public TipKorisnikaServiceImpl(AppDbContext context, IMapper mapper, ITipKorisnikaValidator validator) : base(context, mapper, validator) {
        }
    }
}
