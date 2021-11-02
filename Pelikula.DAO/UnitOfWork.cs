using Pelikula.DAO.Dao;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelikula.DAO
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context = new AppDbContext();
        private AbstractDAO<Zanr, int> zanrRepository;

        public AbstractDAO<Zanr, int> ZanrRepository
        {
            get
            {

                if (this.zanrRepository == null)
                {
                    this.zanrRepository = new AbstractDAO<Zanr, int>(context);
                }
                return zanrRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                context.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
