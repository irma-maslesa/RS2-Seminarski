using Microsoft.EntityFrameworkCore;
using Pelikula.DAO;

namespace Pelikula.REST
{
    public static class SetupService
    {
        public static void Init(AppDbContext context) {
            //context.Database.Migrate();
        }
    }
}
