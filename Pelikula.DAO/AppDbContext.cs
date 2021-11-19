

using Microsoft.EntityFrameworkCore;
using Pelikula.DAO.Model;

namespace Pelikula.DAO {
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Zanr> Zanr { get; set; }
        public virtual DbSet<TipKorisnika> TipKorisnika { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<JedinicaMjere> JedinicaMjere { get; set; }
        public virtual DbSet<Obavijest> Obavijest { get; set; }
        public virtual DbSet<Anketa> Anketa { get; set; }
        public virtual DbSet<AnketaOdgovor> AnketaOdgovor { get; set; }
    }
}
