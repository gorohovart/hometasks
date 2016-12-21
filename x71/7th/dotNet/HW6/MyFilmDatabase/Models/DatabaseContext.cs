using System.Data.Entity;

namespace MyFilmDatabase.Models
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Film> Films { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
        public DatabaseContext() : base("Name=DatabaseContext")
        {
            
        }
    }
}