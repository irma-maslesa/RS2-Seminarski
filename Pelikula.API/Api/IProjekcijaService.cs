﻿using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Projekcija;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pelikula.API.Api
{
    public interface IProjekcijaService : ICrudService<ProjekcijaResponse, ProjekcijaInsertRequest, ProjekcijaUpdateRequest>
    {
        PagedPayloadResponse<ProjekcijaResponse> GetActive(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting);

        Task<ListPayloadResponse<ProjekcijaResponse>> GetPreporucene(string korisnickoIme);

        PayloadResponse<string> PosjetiProjekciju(int projekcijaId, int korisnikId);
    }
}
