using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;
using Pelikula.CORE.Helper.Response;
using Pelikula.API.Model.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Text.Json;
using System.Web;
using Newtonsoft.Json;
using System.Linq;

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

        [HttpPost("get")]
        public virtual PagedPayloadResponse<ResponseDTO> Get(FilterModel filter)
        {
            return readService.Get(filter.Pagination, filter.Filter, filter.Sorting);
        }

        [HttpGet("{id}")]
        public virtual PayloadResponse<ResponseDTO> GetById(int id)
        {
            return readService.GetById(id);
        }
    }
}
