using _38_EntityFramework_CodeFirst_2.Models;
using Microsoft.EntityFrameworkCore;

namespace _38_EntityFramework_CodeFirst_2.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=KDK-302-YZ-PC21;Initial Catalog=CodeFirst1;Integrated Security=True;Encrypt=False;");
            optionsBuilder.UseSqlServer("Data Source=BKARACA\\SQLEXPRESS;Initial Catalog=CF;Integrated Security=True;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //Aşağıdaki gibi tek tek konfigürasyonları eklemek yerine assembly'deki tüm konfigürasyonları uygular.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectAssembly).Assembly);

            //modelBuilder.ApplyConfiguration(new CategoryConfig());
            //modelBuilder.ApplyConfiguration(new ProductDetailConfig());
            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new ProductTagConfig());
            //modelBuilder.ApplyConfiguration(new CustomerConfig());
            //modelBuilder.ApplyConfiguration(new OrderConfig());
        }
    }
}
