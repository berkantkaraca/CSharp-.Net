using _40_EntityFramework_Inheritance.Models;
using Microsoft.EntityFrameworkCore;

namespace _40_EntityFramework_Inheritance.Contexts
{
    public class TPHAppDbContext : DbContext
    {
        //TPH (Table Per Hierarchy): bu strateji veritabanı tasarımında ilişkiyi yansıtan tek bir tablo oluşturur. Hangi nesnenin hangi tür olduğunu belirtmek için bir Discriminator (ayırıcı) kolonu ekler. 

        //Avantajları
        //veri tek bir yerden yönetilir
        //Basit yapı, performansı yüksek (join yok)

        //Dezavantajları
        //Boş sutunlar 
        //normalizasyon kurallarına aykırı

        //loglama, monitoring, arıza takip sistemlerinde kullanılır

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

            //Discriminator özelleştirme
            modelBuilder.Entity<Employee>()
                .HasDiscriminator<string>("EmpType")
                .HasValue<Manager>("Müdür")
                .HasValue<Developer>("Geliştirici");
        }
    }
}
//Özel context için migration ve update database komutları
//Add-Migration InitialCreate -Context TPHAppDbContext => birden fazla context'in varsa bu şekilde atılır
//Update-Database -Context TPHAppDbContext
