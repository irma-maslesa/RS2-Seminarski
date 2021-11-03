using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Validation
{
    public class KorisnikValidatorImpl : BaseValidatorImpl<Korisnik>, IKorisnikValidator
    {
        public KorisnikValidatorImpl(AppDbContext context) : base(context)
        {
        }
    }
}
