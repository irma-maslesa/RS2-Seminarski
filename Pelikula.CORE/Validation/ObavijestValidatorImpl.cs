using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Validation
{
    public class ObavijestValidatorImpl : BaseValidatorImpl<Obavijest>, IObavijestValidator
    {
        public ObavijestValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
