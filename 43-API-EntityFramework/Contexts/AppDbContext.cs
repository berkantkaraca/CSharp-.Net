using _43_API_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace _43_API_EntityFramework.Contexts
{
    public class AppDbContext : DbContext
    {
        //Option Pattern: Constructordan connection alınacak. Bunun için IoC kaydı yapılmalı
        //nesnenin yaşam döngüsüne karar veririz
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(1000);

            modelBuilder.Entity<Product>()
                .Property(p => p.RowVersion)
                .IsRowVersion(); //Her satır güncellendiğinde yeni bir versiyon no atılacak ve buna göre takip edilecek

            modelBuilder.Entity<Product>()
                .HasIndex(p => new {p.Name, p.IsDeleted }); //çok sık sorgu atılacakları indexlersek sorgu performansı artar

            //Softdelete olduğundan her seferinde where atamak yerine burda merkezi yazıldı
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);

            //Category
            modelBuilder.Entity<Category>()
               .Property(c => c.Name)
               .HasMaxLength(150);
        }
    }
}
