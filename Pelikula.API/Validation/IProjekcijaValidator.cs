using Pelikula.API.Model.Projekcija;
using Pelikula.DAO.Model;
using System.Collections.Generic;

namespace Pelikula.API.Validation
{
    public interface IProjekcijaValidator : IBaseValidator<Projekcija>
    {
        void ValidateEntityExists(int? id, ProjekcijaUpsertRequest request);
        void ValidateTermin(List<ProjekcijaTerminUpsertRequest> requests, int trajanjeFilma);
        void ValidateTerminExists(int projekcijaTerminId);
    }
}
