using Microsoft.EntityFrameworkCore;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Pelikula.DAO.Dao
{
    public class ZanrDAO:AbstractDAO<Zanr, int>
    {
        public ZanrDAO(AppDbContext context) : base(context)
        {

        }
    }
}
