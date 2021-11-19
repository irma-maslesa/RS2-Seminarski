using AutoMapper;
using Pelikula.API.Api;
using Pelikula.API.Model.JedinicaMjere;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.CORE.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class JedinicaMjereServiceImpl :
        CrudServiceImpl<JedinicaMjereResponse, JedinicaMjere, JedinicaMjereUpsertRequest, JedinicaMjereUpsertRequest>,
        IJedinicaMjereService
    {

        protected new readonly IJedinicaMjereValidator Validator;

        public JedinicaMjereServiceImpl(AppDbContext context, IMapper mapper, IJedinicaMjereValidator validator) : base(context, mapper, validator)
        {
            Validator = validator;
        }

        public override PayloadResponse<JedinicaMjereResponse> Insert(JedinicaMjereUpsertRequest request)
        {
            Validator.ValidateUpsertRequest(request);

            JedinicaMjere entity = Mapper.Map<JedinicaMjereUpsertRequest, JedinicaMjere>(request);
            entity = Context.Set<JedinicaMjere>().Add(entity).Entity;

            Context.SaveChanges();

            JedinicaMjereResponse response = Mapper.Map<JedinicaMjere, JedinicaMjereResponse>(entity);

            return new PayloadResponse<JedinicaMjereResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<JedinicaMjereResponse> Update(int id, JedinicaMjereUpsertRequest request)
        {
            Validator.ValidateEntityExists(id);
            Validator.ValidateUpsertRequest(request, id);

            JedinicaMjere entity = Context.Set<JedinicaMjere>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<JedinicaMjere>().Update(entity);
            Context.SaveChanges();

            JedinicaMjereResponse response = Mapper.Map<JedinicaMjere, JedinicaMjereResponse>(entity);

            return new PayloadResponse<JedinicaMjereResponse>(HttpStatusCode.OK, response);

        }
    }
}
