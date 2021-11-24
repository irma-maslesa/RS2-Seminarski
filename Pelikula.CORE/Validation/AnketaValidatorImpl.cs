using Pelikula.API.Model.Anketa;
using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Validation
{
    public class AnketaValidatorImpl : BaseValidatorImpl<Anketa>, IAnketaValidator
    {
        public AnketaValidatorImpl(AppDbContext context) : base(context)
        {
        }

        public void ValidateOdgovori(List<AnketaOdgovorInsertRequest> requests)
        {
            if (requests.GroupBy(e => e.Odgovor).Any(x => x.Skip(1).Any()))
                throw new UserException($"Anketa ne smije imati iste odgovore!", HttpStatusCode.BadRequest);
        }

        public void ValidateOdgovori(List<AnketaOdgovorUpdateRequest> requests)
        {
            if (requests.GroupBy(e => e.Odgovor).Any(x => x.Skip(1).Any()))
                throw new UserException($"Anketa ne smije imati iste odgovore!", HttpStatusCode.BadRequest);
        }

        public void ValidateOdgovorExists(int anketaOdgovorId)
        {
            if (Context.AnketaOdgovor.Find(anketaOdgovorId) == null)
                throw new UserException($"Odgovor ({anketaOdgovorId}) ne postoji!", HttpStatusCode.BadRequest);

        }

        public void ValidateKorisnikOdgovorDoesNotExists(int korisnikId, int anketaOdgovorId)
        {
            int anketaId = Context.AnketaOdgovor.Find(anketaOdgovorId).AnketaId;
            List<int> anketaOdgovorIds = Context.AnketaOdgovor.Where(e => e.AnketaId == anketaId).Select(e => e.Id).ToList();

            if (Context.AnketaOdgovorKorisnik.Any(e => e.KorisnikId == korisnikId && anketaOdgovorIds.Contains(e.AnketaOdgovorId)))
                throw new UserException($"Korisnik je već odgovorio na anketu!", HttpStatusCode.BadRequest);

        }

        public void ValidateAnketaIsNotClosed(int id)
        {
            if (Context.Anketa.Find(id)?.ZakljucenoDatum != null)
                throw new UserException($"Anketa ({id}) je već zatvorena!", HttpStatusCode.BadRequest);

        }
    }
}
