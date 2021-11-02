using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadController<ResponseDTO, SearchDTO> :
        ControllerBase
        where ResponseDTO : class
        where SearchDTO : class
    {
        protected readonly READService<ResponseDTO, SearchDTO> readService;

        public ReadController(READService<ResponseDTO, SearchDTO> readService)
        {
            this.readService = readService;
        }

        [HttpGet]
        public virtual IList<ResponseDTO> Get([FromQuery] SearchDTO search)
        {
            return readService.Get(search);
        }

        [HttpGet("{id}")]
        public virtual ResponseDTO GetById(int id)
        {
            return readService.GetById(id);
        }
    }
}
