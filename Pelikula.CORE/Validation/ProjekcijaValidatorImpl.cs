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
        public ProjekcijaValidatorImpl(AppDbContext context) : base(context) {
        }

        public void ValidateEntityExists(int? id, ProjekcijaUpsertRequest request) {
            bool postojiProjekcija = false;

            if (id.HasValue)
                postojiProjekcija = Context.Projekcija.Any(
                e => e.FilmId == request.FilmId &&
                ((request.VrijediOd.Date >= e.VrijediOd.Date && request.VrijediOd.Date <= e.VrijediDo.Date) ||
                 (request.VrijediDo.Date >= e.VrijediOd.Date && request.VrijediDo.Date <= e.VrijediDo.Date)) &&
                 e.Id != id);

            else
                postojiProjekcija = Context.Projekcija.Any(
                    e => e.FilmId == request.FilmId &&
                    ((request.VrijediOd.Date >= e.VrijediOd.Date && request.VrijediOd.Date <= e.VrijediDo.Date) ||
                     (request.VrijediDo.Date >= e.VrijediOd.Date && request.VrijediDo.Date <= e.VrijediDo.Date)));

            if (postojiProjekcija)
                throw new UserException($"Projekcija se poklapa sa već postojećom!", HttpStatusCode.BadRequest);
        }

        public void ValidateTermin(List<ProjekcijaTerminUpsertRequest> requests, int trajanjeFilma) {
            if (requests.GroupBy(e => e.Termin.TimeOfDay).Any(x => x.Skip(1).Any()))
                throw new UserException($"Projekcija ne smije imati iste termine!", HttpStatusCode.BadRequest);

            var orderedRequests = requests.OrderByDescending(e => e.Termin.TimeOfDay).ToList();
            for (int i = 0; i < orderedRequests.Count - 1; i++)
                if ((orderedRequests[i].Termin.TimeOfDay - orderedRequests[i + 1].Termin.TimeOfDay).TotalMinutes < (trajanjeFilma + 10))
                    throw new UserException($"Razlika između početka projekcija mora biti najmanje {trajanjeFilma + 10} minuta!", HttpStatusCode.BadRequest);

        }

        public void ValidateTerminExists(int projekcijaTerminId) {
            if (!Context.ProjekcijaTermin.Any(e => e.Id == projekcijaTerminId))
                throw new UserException($"Termin({projekcijaTerminId}) ne postoji! ", HttpStatusCode.BadRequest);
        }
    }
}
