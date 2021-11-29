using Pelikula.API.Model.Projekcija;
using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Validation
{
    public class ProjekcijaValidatorImpl : BaseValidatorImpl<Projekcija>, IProjekcijaValidator
    {
        public ProjekcijaValidatorImpl(AppDbContext context) : base(context)
        {
        }

        public void ValidateEntityExists(ProjekcijaInsertRequest request)
        {
            bool postojiProjekcija = Context.Projekcija.Any(
                e => e.FilmId == request.FilmId &&
                ((request.VrijediOd.Date >= e.VrijediOd.Date && request.VrijediOd.Date <= e.VrijediDo.Date) ||
                 (request.VrijediDo.Date >= e.VrijediOd.Date && request.VrijediDo.Date <= e.VrijediDo.Date)));

            if (postojiProjekcija)
                throw new UserException($"Projekcija se poklapa sa već postojećom!", HttpStatusCode.BadRequest);

        }

        public void ValidateEntityExists(int id, ProjekcijaUpdateRequest request)
        {
            bool postojiProjekcija = Context.Projekcija.Any(
                e => e.FilmId == request.FilmId &&
                ((request.VrijediOd.Date >= e.VrijediOd.Date && request.VrijediOd.Date <= e.VrijediDo.Date) ||
                 (request.VrijediDo.Date >= e.VrijediOd.Date && request.VrijediDo.Date <= e.VrijediDo.Date)) &&
                 e.Id != id);

            if (postojiProjekcija)
                throw new UserException($"Projekcija se poklapa sa već postojećom!", HttpStatusCode.BadRequest);
        }

        public void ValidateTermin(List<ProjekcijaTerminInsertRequest> requests)
        {
            if (requests.GroupBy(e => e.Termin).Any(x => x.Skip(1).Any()))
                throw new UserException($"Projekcija ne smije imati iste termine!", HttpStatusCode.BadRequest);
        }
        public void ValidateTermin(List<ProjekcijaTerminUpdateRequest> requests)
        {
            if (requests.GroupBy(e => e.Termin).Any(x => x.Skip(1).Any()))
                throw new UserException($"Projekcija ne smije imati iste termine!", HttpStatusCode.BadRequest);
        }
    }
}
