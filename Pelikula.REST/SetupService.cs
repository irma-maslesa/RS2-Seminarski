using Microsoft.EntityFrameworkCore;
using Pelikula.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelikula.REST
{
    public static class SetupService
    {
        public static void Init(AppDbContext context) {
            context.Database.Migrate();
        }
    }
}
