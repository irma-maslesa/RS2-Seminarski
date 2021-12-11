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
        protected new readonly ICrudService<ResponseDTO, InsertDTO, UpdateDTO> Service;

        public CrudController(ICrudService<ResponseDTO, InsertDTO, UpdateDTO> service) : base(service) {
            Service = service;
        }

        [HttpPost]
        public virtual PayloadResponse<ResponseDTO> Insert([FromBody] InsertDTO dtoObject) {
            return Service.Insert(dtoObject);
        }

        [HttpPut("{id}")]
        public virtual PayloadResponse<ResponseDTO> Update(int id, UpdateDTO dtoObject) {
            return Service.Update(id, dtoObject);
        }

        [HttpDelete("{id}")]
        public PayloadResponse<string> Delete(int id) {
            return Service.Delete(id);
        }
    }
}
