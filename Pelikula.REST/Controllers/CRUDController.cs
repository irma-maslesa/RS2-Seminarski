using Microsoft.AspNetCore.Mvc;
using Pelikula.API.Api;
using Pelikula.CORE.Helper.Response;

namespace API.Controllers
{
    public class CrudController<ResponseDTO, InsertDTO, UpdateDTO> :
        ReadController<ResponseDTO>
        where ResponseDTO : class
        where InsertDTO : class
        where UpdateDTO : class
    {
        protected readonly ICrudService<ResponseDTO, InsertDTO, UpdateDTO> crudService;

        public CrudController(ICrudService<ResponseDTO, InsertDTO, UpdateDTO> crudService):base(crudService)
        {
            this.crudService = crudService;
        }

        [HttpPost]
        public virtual PayloadResponse<ResponseDTO> Insert([FromBody] InsertDTO dtoObject)
        {
            return crudService.Insert(dtoObject);
        }

        [HttpPut("{id}")]
        public virtual PayloadResponse<ResponseDTO> Update(int id, UpdateDTO dtoObject)
        {
            return crudService.Update(id, dtoObject);
        }

        [HttpDelete("{id}")]
        public PayloadResponse<string> Delete(int id)
        {
            return crudService.Delete(id);
        }
    }
}
