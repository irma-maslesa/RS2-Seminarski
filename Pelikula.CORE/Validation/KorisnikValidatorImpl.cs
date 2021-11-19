using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Validation
{
    public class KorisnikValidatorImpl : BaseValidatorImpl<Korisnik>, IKorisnikValidator
    {
        public KorisnikValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
