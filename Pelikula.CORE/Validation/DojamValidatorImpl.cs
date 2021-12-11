using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Validation
{
    public class DojamValidatorImpl : BaseValidatorImpl<Dojam>, IDojamValidator
    {
        public DojamValidatorImpl(AppDbContext context) : base(context) {
        }

        public void ValidateComboDoesNotExist(int? id, int korisnikId, int projekcijaId) {
            if (id.HasValue) {
                if (Context.Dojam.Any(e => e.KorisnikId == korisnikId && e.ProjekcijaId == projekcijaId &&
                                                        e.Id != id.Value))
                    throw new UserException($"Korisnik({korisnikId}) je već ostavio dojam za projekciju({projekcijaId})!", HttpStatusCode.BadRequest);
            }
            else {
                if (Context.Dojam.Any(e => e.KorisnikId == korisnikId && e.ProjekcijaId == projekcijaId))
                    throw new UserException($"Korisnik({korisnikId}) je već ostavio dojam za projekciju({projekcijaId})!", HttpStatusCode.BadRequest);

            }
        }
    }
}
