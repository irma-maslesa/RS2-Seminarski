using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Sala;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class SalaServiceImpl :
        CrudServiceImpl<SalaResponse, Sala, SalaUpsertRequest, SalaUpsertRequest>,
        ISalaService
    {
        public SalaServiceImpl(AppDbContext context, IMapper mapper, ISalaValidator validator) : base(context, mapper, validator)
        {
        }

        public override PagedPayloadResponse<SalaResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Sala> entityList = Context.Set<Sala>().Include(e => e.Sjediste).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Sala>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Sala>.SortData(sorting, entityList) : entityList;

            foreach (var entity in entityList)
            {
                entity.Sjediste = entity.Sjediste.OrderBy(e => e.Red).ThenBy(e => e.Broj).ToList();
            }

            List<SalaResponse> responseList = Mapper.Map<List<SalaResponse>>(entityList);


            PaginationUtility.PagedData<SalaResponse> pagedResponse = PaginationUtility.Paginaion<SalaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<SalaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<SalaResponse> GetById(int id)
        {
            Validator.ValidateEntityExists(id);

            Sala entity = Context.Set<Sala>().Include(e => e.Sjediste).FirstOrDefault(e => e.Id == id);
            entity.Sjediste = entity.Sjediste.OrderBy(e => e.Red).ThenBy(e => e.Broj).ToList();

            SalaResponse response = Mapper.Map<SalaResponse>(entity);

            return new PayloadResponse<SalaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<SalaResponse> Insert(SalaUpsertRequest request)
        {
            Sala entity = Mapper.Map<SalaUpsertRequest, Sala>(request);

            entity.BrojSjedista = entity.BrojSjedistaDuzina * entity.BrojSjedistaSirina;
            entity = Context.Set<Sala>().Add(entity).Entity;

            Context.SaveChanges();

            char red = 'A';


            var sjedista = new List<Sjediste>();

            for (int i = 0; i < entity.BrojSjedistaDuzina; i++)
            {
                for (int j = 1; j <= entity.BrojSjedistaSirina; j++)
                {
                    Sjediste sjediste = new Sjediste
                    {
                        Broj = j,
                        Red = red.ToString(),
                        SalaId = entity.Id
                    };

                    sjedista.Add(sjediste);
                }

                red++;
            }

            Context.Sjediste.AddRange(sjedista);

            Context.SaveChanges();

            entity.Sjediste = entity.Sjediste.OrderBy(e => e.Red).ThenBy(e => e.Broj).ToList();
            SalaResponse response = Mapper.Map<Sala, SalaResponse>(entity);

            return new PayloadResponse<SalaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<SalaResponse> Update(int id, SalaUpsertRequest request)
        {
            Validator.ValidateEntityExists(id);

            Sala entity = Context.Set<Sala>().Include(e => e.Sjediste).FirstOrDefault(e => e.Id == id);

            entity = Mapper.Map(request, entity);

            Context.Set<Sala>().Update(entity);
            Context.SaveChanges();

            entity.Sjediste = entity.Sjediste.OrderBy(e => e.Red).ThenBy(e => e.Broj).ToList();
            SalaResponse response = Mapper.Map<Sala, SalaResponse>(entity);

            return new PayloadResponse<SalaResponse>(HttpStatusCode.OK, response);
        }

    }
}
