using Pelikula.API.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelikula.CORE.Impl
{
    public class READServiceImpl<ResponseDTO, Entity, SearchDTO> :
        READService<ResponseDTO, SearchDTO>
        where ResponseDTO : class
        where Entity : class
        where SearchDTO : class
    {
        //public ApplicationDbContext context { get; set; }
        //protected readonly IMapper mapper;

        //public READServiceImpl(ApplicationDbContext context, IMapper mapper)
        //{
        //    this.context = context;
        //    this.mapper = mapper;
        //}

        public virtual IList<ResponseDTO> Get(SearchDTO search = null)
        {
            //List<Entity> entityList = context.Set<Entity>().ToList();

            //return mapper.Map<List<ResponseDTO>>(entityList);

            return null;
        }

        public virtual ResponseDTO GetById(int id)
        {
            //Entity entity = context.Set<Entity>().Find(id);

            //if (entity == null)
            //    throw new UserException($"{typeof(Entity).Name}({id}) ne postoji!");

            //return mapper.Map<ResponseDTO>(entity);

            return null;
        }
    }
}
