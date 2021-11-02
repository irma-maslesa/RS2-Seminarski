using Microsoft.EntityFrameworkCore;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelikula.REST { 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Zanr> Zanr { get; set; }
    }
}
