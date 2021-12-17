using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using System;
using System.Net;

namespace Pelikula.CORE.Validation
{
    public class IzvjestajValidatorImpl : IIzvjestajValidator
    {
        public AppDbContext Context { get; set; }

        public IzvjestajValidatorImpl(AppDbContext context) {
            Context = context;
        }

        public void ValidateDatume(DateTime datumOd, DateTime datumDo) {
            if(datumOd > datumDo)
                throw new UserException("Neispravni datumi! ", HttpStatusCode.BadRequest);
        }
    }
}
