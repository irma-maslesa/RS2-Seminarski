using Pelikula.API.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelikula.CORE.Impl
{
    class CRUDServiceImpl<ResponseDTO, Entity, SearchDTO, InsertDTO, UpdateDTO> :
        READServiceImpl<ResponseDTO, Entity, SearchDTO>,
        CRUDService<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO>
        where ResponseDTO : class
        where Entity : class
        where SearchDTO : class
        where InsertDTO : class
        where UpdateDTO : class
    {
        //public ApplicationDbContext context { get; set; }
        //protected readonly IMapper mapper;

        //public CRUDServiceImpl(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        //{
        //    this.context = context;
        //    this.mapper = mapper;
        //}

        public virtual ResponseDTO Insert(InsertDTO request)
        {
            //Entity entity = mapper.Map<InsertDTO, Entity>(request);
            //entity = context.Set<Entity>().Add(entity).Entity;

            //context.SaveChanges();

            //return mapper.Map<Entity, ResponseDTO>(entity);

            return null;
        }

        public virtual ResponseDTO Update(int id, UpdateDTO request)
        {
            //Entity entity = context.Set<Entity>().Find(id);

            //if (entity == null)
            //    throw new UserException($"{typeof(Entity).Name}({id}) ne postoji!");

            //entity = mapper.Map(request, entity);

            //context.Set<Entity>().Update(entity);
            //context.SaveChanges();

            //return mapper.Map<Entity, ResponseDTO>(entity);
           
            return null;
            
        }

        public virtual void Delete(int id)
        {
            //Entity entity = context.Set<Entity>().Find(id);

            //if (entity == null)
            //    throw new UserException($"{typeof(Entity).Name}({id}) ne postoji!");

            //context.Set<Entity>().Remove(entity);
            //context.SaveChanges();
        }
    }
}
