using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pelikula.API.Api;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.CORE.Validation;
using Pelikula.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Impl
{
    public class ReadServiceImpl<ResponseDTO, Entity, SearchDTO> :
        IReadService<ResponseDTO, SearchDTO>
        where ResponseDTO : class
        where Entity : class
        where SearchDTO : class
    {
        protected AppDbContext Context { get; set; }
        protected readonly IMapper Mapper;
        protected readonly IBaseValidator<Entity> Validator;

        public ReadServiceImpl(AppDbContext context, IMapper mapper, IBaseValidator<Entity> validator)
        {
            this.Context = context;
            this.Mapper = mapper;
            this.Validator = validator;
        }

        public virtual ListPayloadResponse<ResponseDTO> Get(SearchDTO search = null)
        {
            List<Entity> entityList = Context.Set<Entity>().ToList();

            List<ResponseDTO> responseList = Mapper.Map<List<ResponseDTO>>(entityList);

            return new ListPayloadResponse<ResponseDTO>(HttpStatusCode.OK, responseList);
        }

        public virtual PayloadResponse<ResponseDTO> GetById(int id)
        {
            Validator.ValidateEntityExists(id);

            Entity entity = Context.Set<Entity>().Find(id);

            ResponseDTO response = Mapper.Map<ResponseDTO>(entity);

            return new PayloadResponse<ResponseDTO>(HttpStatusCode.OK, response);
        }
    }
}
