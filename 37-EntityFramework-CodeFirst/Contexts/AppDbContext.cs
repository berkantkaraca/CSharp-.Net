using _37_EntityFramework_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace _37_EntityFramework_CodeFirst.Contexts
{
    public class AppDbContext : DbContext
    {
        //Hangi nesneleri orm olarak kullanacağımızı belirtiriz
        //Connection string tanımlaması gönderilir
        //Configuration işlemleri yapılır
        //Veritabanı ile uygulama arasında bir köprü görevi görür. Tüm veri operasyonları, sorgular, crud işlemleri vb. ayarlar dbcontext üzerinden gerçekleştirilir.

        public DbSet<Product> Products { get; set; } // Product nesnesini Products tablosuna mapler
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; } // Eğer ProductDetail DbSet tanımlanmazsa Product ile ilişkili olduğu için migration da tablo oluşturulur. Ama ProductDetail tablosunu sorgulayamazsın
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ProductTag> ProductTag { get; set; }


        //Sql konfigrasyonları yapılır
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //UseSqlServer Microsoft.EntityFrameworkCore.SqlServer paketinden geliyor
            optionsBuilder.UseSqlServer("Data Source=BKARACA\\SQLEXPRESS;Initial Catalog=CF;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;");
        }

        //Model oluşturulma anındaki operasyonları tanımlarız
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluentapi teknolojisi kullanılır
            base.OnModelCreating(modelBuilder); //basedeki yapıların kalmasını isteriz

            //özel konfigrasyonlar
            modelBuilder.Entity<Category>()
                .ToTable("TblKategori") //Tablo adı gösterme
                .HasKey(x => x.Id); //primary key gösterme

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique(); //benzersiz yapma. bunun için index olması lazım öncesinde

            modelBuilder.Entity<Product>()
                .Ignore(p => p.Deneme); //migrationda eklenmesini istemediğimiz propertyler için

            modelBuilder.Entity<Product>()
                .HasData( //başlangıç verisi ekleme. Databese kuralları eklenmediği için burada Id ataması yapmak zorundayız
                    new Product() { Id = 1, Name = "Ürün1", Price = 100, CategoryId = 1 },
                    new Product() { Id = 2, Name = "Ürün2", Price = 200, CategoryId = 1 },
                    new Product() { Id = 3, Name = "Ürün3", Price = 300, CategoryId = 2 }
                );

            modelBuilder.Entity<Product>()
                .Property(p => p.Name) //sütün seçimi
                .HasColumnName("UrunAdi") // kolon adını değiştirme
                .HasColumnType("nvarchar(50)") //sütün tipi
                .HasColumnOrder(3) //tabloda oluşturma sırası
                .HasDefaultValue("Product1") //nesne tarafında çalışan default
                .HasDefaultValueSql("GETDATE()") //sql de çalışan default
                .IsRequired(false) //null olabilir
                .HasMaxLength(50) //HasColumnType("nvarchar(50)") tanımlamana gerek yok bunu yazarsan. aynısı
                .HasComputedColumnSql("[FirstName]" + ' ' + "[LastName]"); //birleşitrme işlemi 

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2); //ikiside aynı işi yarar. ondalık kısımda kaç değer göstercek

            //Burda yapılan tanımlamalar entity içindeki tanımlamaları ezer. Entity içinde null tanımladın, burda not null tanımladıysan buranın sözü geçer
        }

    }
}
