using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GIS_APP
{
    public class Context : DbContext
    {
        public Context()
            : base("name=PostgresConnection")
        {
        }

        public DbSet<Position> Positions { get; set; }
    }
}