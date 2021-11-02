using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;

namespace API.Controllers
{
    public class CRUDController<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO> :
        ReadController<ResponseDTO, SearchDTO>
        where ResponseDTO : class
        where SearchDTO : class
        where InsertDTO : class
        where UpdateDTO : class
    {
        protected readonly CRUDService<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO> crudService;

        public CRUDController(CRUDService<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO> crudService):base(crudService)
        {
            this.crudService = crudService;
        }

        [HttpPost]
        public virtual ResponseDTO Insert([FromBody] InsertDTO trener)
        {
            return crudService.Insert(trener);
        }

        [HttpPut("{id}")]
        public virtual ResponseDTO Update(int id, UpdateDTO trener)
        {
            return crudService.Update(id, trener);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            crudService.Delete(id);
            //return crudService.delete(id);
        }
    }
}
