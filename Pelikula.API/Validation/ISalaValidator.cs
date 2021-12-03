using Pelikula.DAO.Model;
using System.Collections.Generic;

namespace Pelikula.API.Validation
{
    public interface ISalaValidator : IBaseValidator<Sala>
    {
        void ValidateSjedistaExist(ICollection<int> sjedistaIds);
    }
}
