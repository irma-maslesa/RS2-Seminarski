using Pelikula.API.Model.Artikal;
using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Linq;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Validation
{
    public class ArtikalValidatorImpl : BaseValidatorImpl<Artikal>, IArtikalValidator
    {
        public ArtikalValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
