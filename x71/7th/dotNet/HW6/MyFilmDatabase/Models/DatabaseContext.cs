using System.Data.Entity;

namespace MyFilmDatabase.Models
{
    public class DatabaseContext : DbContext
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