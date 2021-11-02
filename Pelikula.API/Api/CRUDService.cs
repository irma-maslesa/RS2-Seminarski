using System;
using System.Collections.Generic;
using System.Text;

namespace Pelikula.API.Api
{
    public interface CRUDService<ResponseDTO, SearchDTO, InsertDTO, UpdateDTO> : READService<ResponseDTO, SearchDTO>
        where ResponseDTO : class
        where SearchDTO : class
        where InsertDTO : class
        where UpdateDTO : class
    {
        ResponseDTO Insert(InsertDTO request);
        ResponseDTO Update(int id, UpdateDTO request);
        void Delete(int id);
    }
}
