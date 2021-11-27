using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Validation
{
    public class FilmValidatorImpl : BaseValidatorImpl<Film>, IFilmValidator
    {
        public FilmValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
