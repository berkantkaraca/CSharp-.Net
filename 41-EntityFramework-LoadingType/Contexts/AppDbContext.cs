using _41_EntityFramework_LoadingType.Models;
using Microsoft.EntityFrameworkCore;

namespace _41_EntityFramework_LoadingType.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KDK-302-YZ-PC21;Initial Catalog=CodeFirst3;Integrated Security=True;Encrypt=False;");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseLazyLoadingProxies();  
        }
    }
}
