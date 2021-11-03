using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;
using Pelikula.CORE.Helper.Response;

namespace API.Controllers
{
    public class CrudController<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO> :
        ReadController<ResponseDTO, SearchDTO>
        where ResponseDTO : class
        where SearchDTO : class
        where InsertDTO : class
        where UpdateDTO : class
    {
        protected readonly ICrudService<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO> crudService;

        public CrudController(ICrudService<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO> crudService):base(crudService)
        {
            this.crudService = crudService;
        }

        [HttpPost]
        public virtual PayloadResponse<ResponseDTO> Insert([FromBody] InsertDTO trener)
        {
            return crudService.Insert(trener);
        }

        [HttpPut("{id}")]
        public virtual PayloadResponse<ResponseDTO> Update(int id, UpdateDTO trener)
        {
            return crudService.Update(id, trener);
        }

        [HttpDelete("{id}")]
        public PayloadResponse<string> Delete(int id)
        {
            return crudService.Delete(id);
        }
    }
}
