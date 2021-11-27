using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Validation
{
    public class SalaValidatorImpl : BaseValidatorImpl<Sala>, ISalaValidator
    {
        public SalaValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
