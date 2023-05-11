using AspNetWebApiExample.Models.ORM;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AspNetWebApiExample.Models.Context
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=WebApiTestDb; Trusted_Connection=True");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Adress { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<University> Universities { get; set;}

    }
}
