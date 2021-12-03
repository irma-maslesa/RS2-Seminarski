using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Validation
{
    public class RezervacijaValidatorImpl : BaseValidatorImpl<Rezervacija>, IRezervacijaValidator
    {
        public RezervacijaValidatorImpl(AppDbContext context) : base(context)
        {
        }

        public void ValidateKorisnikTermin(int? id, int korisnikId, int projekcijaTerminId)
        {
            if (id.HasValue)
            {
                if (Context.Rezervacija.Any(e => e.KorisnikId == korisnikId && e.ProjekcijaTerminId == projekcijaTerminId && e.Id != id.Value))
                    throw new UserException($"Korisnik(${korisnikId}) ima već kreiranu rezervaciju za termin({projekcijaTerminId})! ", HttpStatusCode.BadRequest);
            }
            else
             if (Context.Rezervacija.Any(e => e.KorisnikId == korisnikId && e.ProjekcijaTerminId == projekcijaTerminId))
                throw new UserException($"Korisnik(${korisnikId}) ima već kreiranu rezervaciju za termin({projekcijaTerminId})! ", HttpStatusCode.BadRequest);

        }


        public void ValidateEntityOtkazano(int id)
        {
            if (Context.Rezervacija.Find(id).DatumOtkazano != null)
                throw new UserException($"Rezervacija({id}) je već otkazana! ", HttpStatusCode.BadRequest);
        }

        public void ValidateEntityProdano(int id)
        {
            if (Context.Rezervacija.Find(id).DatumProdano != null)
                throw new UserException($"Rezervacija({id}) je već prodana! ", HttpStatusCode.BadRequest);
        }
    }
}
