using Pelikula.API.Model.Projekcija;
using Pelikula.DAO.Model;
using System.Collections.Generic;

namespace Pelikula.API.Validation
{
    public interface IProjekcijaValidator : IBaseValidator<Projekcija>
    {
        void ValidateEntityExists(ProjekcijaInsertRequest request);
        void ValidateEntityExists(int id, ProjekcijaUpdateRequest request);
        void ValidateTermin(List<ProjekcijaTerminInsertRequest> requests);
        void ValidateTermin(List<ProjekcijaTerminUpdateRequest> requests);
    }
}
