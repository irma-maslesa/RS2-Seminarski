using System;

namespace Pelikula.API.Validation
{
    public interface IIzvjestajValidator
    {
        void ValidateDatume(DateTime? datumOd, DateTime? datumDo);
    }
}
