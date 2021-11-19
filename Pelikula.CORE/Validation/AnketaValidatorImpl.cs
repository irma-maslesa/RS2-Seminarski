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
            if(requests.GroupBy(e => e.Odgovor).Any(x => x.Skip(1).Any()))
                throw new UserException($"Anketa ne smije imati iste odgovore!", HttpStatusCode.BadRequest);
        }

        public void ValidateOdgovori(List<AnketaOdgovorUpdateRequest> requests)
        {
            if (requests.GroupBy(e => e.Odgovor).Any(x => x.Skip(1).Any()))
                throw new UserException($"Anketa ne smije imati iste odgovore!", HttpStatusCode.BadRequest);
        }
    }
}
