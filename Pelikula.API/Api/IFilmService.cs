using Pelikula.API.Model.Film;

namespace Pelikula.API.Api
{
    public interface IFilmService : ICrudService<FilmResponse, FilmUpsertRequest, FilmUpsertRequest>
    {
    }
}
