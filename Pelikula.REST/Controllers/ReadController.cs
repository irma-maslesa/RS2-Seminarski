using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;
using Pelikula.CORE.Helper.Response;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadController<ResponseDTO, SearchDTO> :
        ControllerBase
        where ResponseDTO : class
        where SearchDTO : class
    {
        protected readonly IReadService<ResponseDTO, SearchDTO> readService;

        public ReadController(IReadService<ResponseDTO, SearchDTO> readService)
        {
            this.readService = readService;
        }

        [HttpGet]
        public virtual ListPayloadResponse<ResponseDTO> Get([FromQuery] SearchDTO search)
        {
            return readService.Get(search);
        }

        [HttpGet("{id}")]
        public virtual PayloadResponse<ResponseDTO> GetById(int id)
        {
            return readService.GetById(id);
        }
    }
}
