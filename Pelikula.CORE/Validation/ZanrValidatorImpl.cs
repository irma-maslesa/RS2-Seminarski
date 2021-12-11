using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Validation
{
    public class ZanrValidatorImpl : BaseValidatorImpl<Zanr>, IZanrValidator
    {
        public ZanrValidatorImpl(AppDbContext context) : base(context) {
        }
    }
}
