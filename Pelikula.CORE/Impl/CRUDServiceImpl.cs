using AutoMapper;
using Pelikula.API.Api;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class CrudServiceImpl<ResponseDTO, Entity, InsertDTO, UpdateDTO> :
        ReadServiceImpl<ResponseDTO, Entity>,
        ICrudService<ResponseDTO, InsertDTO, UpdateDTO>
        where ResponseDTO : class
        where Entity : class
        where InsertDTO : class
        where UpdateDTO : class
    {

        public CrudServiceImpl(AppDbContext context, IMapper mapper, IBaseValidator<Entity> validator) : base(context, mapper, validator)
        {
        }

        public virtual PayloadResponse<ResponseDTO> Insert(InsertDTO request)
        {
            Entity entity = Mapper.Map<InsertDTO, Entity>(request);
            entity = Context.Set<Entity>().Add(entity).Entity;

            Context.SaveChanges();

            ResponseDTO response = Mapper.Map<Entity, ResponseDTO>(entity);

            return new PayloadResponse<ResponseDTO>(HttpStatusCode.OK, response);
        }

        public virtual PayloadResponse<ResponseDTO> Update(int id, UpdateDTO request)
        {

            Validator.ValidateEntityExists(id);

            Entity entity = Context.Set<Entity>().Find(id);
            
            entity = Mapper.Map(request, entity);

            Context.Set<Entity>().Update(entity);
            Context.SaveChanges();

            ResponseDTO response = Mapper.Map<Entity, ResponseDTO>(entity);

            return new PayloadResponse<ResponseDTO>(HttpStatusCode.OK, response);

        }

        public virtual PayloadResponse<string> Delete(int id)
        {

            Validator.ValidateEntityExists(id);

            Entity entity = Context.Set<Entity>().Find(id);

            Context.Set<Entity>().Remove(entity);
            Context.SaveChanges();

            string response = $"{typeof(Entity).Name} obrisan!";

            return new PayloadResponse<string>(HttpStatusCode.OK, response);
        }
    }
}
