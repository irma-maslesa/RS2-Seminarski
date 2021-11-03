using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.API.Validation;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Pelikula.CORE.Filter;

namespace Pelikula.CORE.Validation
{
    public class BaseValidatorImpl<Entity> : IBaseValidator<Entity>
        where Entity : class
    {
        public AppDbContext Context { get; set; }

        public BaseValidatorImpl(AppDbContext context)
        {
            Context = context;
        }

        public virtual void ValidateEntityExists(int id)
        {
            Entity entity = Context.Set<Entity>().Find(id);

            if (entity == null)
                throw new UserException($"{typeof(Entity).Name}({id}) ne postoji!", HttpStatusCode.BadRequest);

        }
    }
}
