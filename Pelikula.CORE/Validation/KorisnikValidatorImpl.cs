using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Validation
{
    public class KorisnikValidatorImpl : BaseValidatorImpl<Korisnik>, IKorisnikValidator
    {
        public KorisnikValidatorImpl(AppDbContext context) : base(context)
        {
        }

        public void ValidateKorisnickoIme(string korisnickoIme, int? id = null)
        {
            if (id.HasValue && Context.Korisnik.Any(e => e.KorisnickoIme == korisnickoIme && e.Id != id.Value))
            {
                throw new UserException($"Korisničko ime {korisnickoIme} je zauzeto!", HttpStatusCode.BadRequest);

            }
            else if(Context.Korisnik.Any(e => e.KorisnickoIme == korisnickoIme))
            {
                throw new UserException($"Korisničko ime {korisnickoIme} je zauzeto!", HttpStatusCode.BadRequest);
            }
        }

        public void ValidateEmail(string email, int? id = null)
        {
            if (id.HasValue && Context.Korisnik.Any(e => e.Email == email && e.Id != id.Value))
            {
                throw new UserException($"Email {email} se već koristi!", HttpStatusCode.BadRequest);
            }
            else if (Context.Korisnik.Any(e => e.Email == email))
            {
                throw new UserException($"Email {email} se već koristi!", HttpStatusCode.BadRequest);
            }
        }
    }
}
