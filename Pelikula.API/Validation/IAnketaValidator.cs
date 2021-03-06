using Pelikula.API.Model.Anketa;
using Pelikula.DAO.Model;
using System.Collections.Generic;

namespace Pelikula.API.Validation
{
    public interface IAnketaValidator : IBaseValidator<Anketa>
    {
        void ValidateOdgovori(List<AnketaOdgovorInsertRequest> requests);
        void ValidateOdgovori(List<AnketaOdgovorUpdateRequest> requests);
        void ValidateOdgovorExists(int anketaOdgovorId);
        void ValidateKorisnikOdgovorDoesNotExists(int korisnikId, int anketaOdgovorId);
        void ValidateAnketaIsNotClosed(int id);
    }
}
