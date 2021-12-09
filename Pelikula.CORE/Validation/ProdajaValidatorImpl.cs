using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Validation
{
    public class ProdajaValidatorImpl : BaseValidatorImpl<Prodaja>, IProdajaValidator
    {
        public ProdajaValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
