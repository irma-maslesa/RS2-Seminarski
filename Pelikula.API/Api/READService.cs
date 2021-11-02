using System.Collections.Generic;

namespace Pelikula.API.Api
{
    public interface READService<ResponseDTO, SearchDTO>
        where ResponseDTO : class
        where SearchDTO : class
    {
        IList<ResponseDTO> Get(SearchDTO search = null);
        ResponseDTO GetById(int id);
    }
}
