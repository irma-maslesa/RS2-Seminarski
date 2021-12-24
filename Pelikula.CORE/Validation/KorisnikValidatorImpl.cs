using Microsoft.EntityFrameworkCore;
using Pelikula.API.Model;
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
        public KorisnikValidatorImpl(AppDbContext context) : base(context) {
        }

        public void ValidateKorisnickoIme(string korisnickoIme, int? id = null) {
            if (id.HasValue && Context.Korisnik.Any(e => e.KorisnickoIme.ToLower() == korisnickoIme.ToLower() && e.Id != id.Value)) {
                throw new UserException($"Korisničko ime {korisnickoIme} je zauzeto!", HttpStatusCode.BadRequest);

            }
            else if (!id.HasValue && Context.Korisnik.Any(e => e.KorisnickoIme.ToLower() == korisnickoIme.ToLower())) {
                throw new UserException($"Korisničko ime {korisnickoIme} je zauzeto!", HttpStatusCode.BadRequest);
            }
        }

        public void ValidateEmail(string email, int? id = null) {
            if (id.HasValue && Context.Korisnik.Any(e => e.Email == email && e.Id != id.Value)) {
                throw new UserException($"Email {email} se već koristi!", HttpStatusCode.BadRequest);
            }
            else if (!id.HasValue && Context.Korisnik.Any(e => e.Email == email)) {
                throw new UserException($"Email {email} se već koristi!", HttpStatusCode.BadRequest);
            }
        }

        public void ValidateTipKorisnika(int id, KorisnikTip tipKorisnika) {
            var uloga = Context.Korisnik
                .Include(e => e.TipKorisnika)
                .Where(e => e.Id == id)
                .Select(e => e.TipKorisnika.Naziv)
                .FirstOrDefault();

            if (uloga.ToLower() != tipKorisnika.ToString().ToLower()) {
                throw new UserException($"Korisnik({id}) nije {tipKorisnika}! ", HttpStatusCode.BadRequest);
            }
        }
    }
}
