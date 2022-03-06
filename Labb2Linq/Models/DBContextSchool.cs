using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2Linq.Models
{
    public class DBContextSchool : DbContext
    {

        public DbSet<Elev> Elever { get; set; }
        public  DbSet<Klass> Klasser { get; set; }
        public DbSet<Kurs> Kurser { get; set; }
        public DbSet<Lärare> Lärare { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = DESKTOP-O8V61A2; Initial Catalog = Labb2Linq; Integrated Security = True;");
        }

    }
}
