using _40_EntityFramework_Inheritance.Models;
using Microsoft.EntityFrameworkCore;

namespace _40_EntityFramework_Inheritance.Contexts
{
    public class TPTAppDbContext : DbContext
    {
        //Table Per Type: Her sınıf için ayrı bir tablo
        //Alt sınıflar, base sınıfı ile ilişkilendirilir (1-1). Veri çekerken birleştirilir(join)
        //Normalizasyonu yüksek, gereksiz sutün yok
        //dezavantajı join

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KDK-302-YZ-PC21;Initial Catalog=CodeFirst3;Integrated Security=True;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .ToTable("Employees");

            modelBuilder.Entity<Developer>()
                .ToTable("Developers")
                .HasBaseType<Employee>();

            modelBuilder.Entity<Manager>()
                .ToTable("Managers")
                .HasBaseType<Employee>();
        }
    }
}

