using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pelikula.API.Validation
{
    public interface IBaseValidator<Entity>
        where Entity : class
    {
        void ValidateEntityExists(int id);
    }
}
