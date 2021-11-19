using Pelikula.API.Model.JedinicaMjere;
using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Validation
{
    public class JedinicaMjereValidatorImpl : BaseValidatorImpl<JedinicaMjere>, IJedinicaMjereValidator
    {
        public JedinicaMjereValidatorImpl(AppDbContext context) : base(context)
        {
        }

        public void ValidateUpsertRequest(JedinicaMjereUpsertRequest request, int? id = null)
        {
            StringBuilder sb = new StringBuilder();

            if (request.Naziv == null)
                sb.Append("Naziv je obavezan! ");
            if (request.KratkiNaziv == null)
                sb.Append("Kratki naziv je obavezan! ");

            if (sb.Length > 0)
                throw new UserException(sb.ToString(), HttpStatusCode.BadRequest);

            if (id.HasValue)
            {
                if (Context.JedinicaMjere.Any(e => (e.KratkiNaziv.ToLower().Equals(request.KratkiNaziv.ToLower()) ||
                                                        e.Naziv.ToLower().Equals(request.Naziv.ToLower())) &&
                                                        e.Id != id.Value))
                    throw new UserException($"Jedinica mjere već postoji!", HttpStatusCode.BadRequest);
            }
            else
            {
                if (Context.JedinicaMjere.Any(e => (e.KratkiNaziv.ToLower().Equals(request.KratkiNaziv.ToLower()) ||
                                                        e.Naziv.ToLower().Equals(request.Naziv.ToLower()))))
                    throw new UserException($"Jedinica mjere već postoji!", HttpStatusCode.BadRequest);
            }
        }
    }
}
