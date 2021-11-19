using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Validation
{
    public class TipKorisnikaValidatorImpl : BaseValidatorImpl<TipKorisnika>, ITipKorisnikaValidator
    {
        public TipKorisnikaValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
