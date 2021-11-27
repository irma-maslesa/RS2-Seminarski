using Pelikula.API.Api;
using Pelikula.API.Model.Film;

namespace API.Controllers
{
    public class FilmController :
        CrudController<FilmResponse, FilmUpsertRequest, FilmUpsertRequest>
    {

        public FilmController(IFilmService service) : base(service)
        {
        }
    }
}
