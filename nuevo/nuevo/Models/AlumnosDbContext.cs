using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace nuevo.Models
{
    
        public class AlumnosDbContext : DbContext
        {
            public static string connection = "DefaultConnection";
            public AlumnosDbContext() : base(connection) { }
            public DbSet<Alumnos> Alumnos { get; set; }
        }
    
}