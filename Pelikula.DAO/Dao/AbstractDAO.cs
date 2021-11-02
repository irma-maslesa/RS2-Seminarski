using Microsoft.EntityFrameworkCore;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Pelikula.DAO.Dao
{
    public abstract class AbstractDAO<Entity, Key> 
        where Entity:class
    {
        internal AppDbContext context;
        internal DbSet<Entity> dbSet;

        public AbstractDAO(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Entity>();
        }

        public virtual IEnumerable<Entity> Get(
            int? page = null,
            int? entitiesPerPage = null,
            Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<Entity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if(page.HasValue && entitiesPerPage.HasValue)
            {
                return query.Skip((page.Value - 1) * entitiesPerPage.Value)
                .Take(entitiesPerPage.Value);
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual Entity GetByID(Key id)
        {
            return dbSet.Find(id);
        }
       
        public virtual Entity Insert(Entity Entity)
        {
            return dbSet.Add(Entity).Entity;
        }

        public virtual void InsertRange(IEnumerable<Entity> Range)
        {
            dbSet.AddRange(Range);
        }

        public virtual void Update(Entity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeleteById(Key id)
        {
            Entity entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(Entity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        
        public virtual int CountAll(
            Expression<Func<Entity, bool>> filter = null)
        {
            IQueryable<Entity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }

        public virtual bool ExistsById(Key id)
        {
            Entity entity = dbSet.Find(id);

            return entity != null;
        }

    }
}
