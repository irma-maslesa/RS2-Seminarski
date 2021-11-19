using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Validation
{
    public class AnketaValidatorImpl : BaseValidatorImpl<Anketa>, IAnketaValidator
    {
        public AnketaValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
