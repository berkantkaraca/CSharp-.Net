using _40_EntityFramework_Inheritance.Models;
using Microsoft.EntityFrameworkCore;

namespace _40_EntityFramework_Inheritance.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KDK-302-YZ-PC21;Initial Catalog=CodeFirst3;Integrated Security=True;Encrypt=False;");
        }
    }
}
