using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyFilmDatabase.Models;

namespace MyFilmDatabase.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}