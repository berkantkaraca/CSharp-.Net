using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _37_EntityFramework_CodeFirst.Models
{
    [Table("TblProducts")] //Tablo ismini değiştirmek için kullanılır
    public class Product
    {
        private decimal _price;

        public Product()
        {
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Product(string name, decimal price, int categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        [Key] //Primary Key olduğunu belirtir. Id yazmasan da primary key yapar
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı boş geçilemez")] //Boş geçilemez
        [Display(Name = "Adınız")] //Ekranda gösterilecek isim
        [MaxLength(100)] //nvarchar(100) yapar, database tarafında max uzunluk kontrolü yapar
        [StringLength(100)] //max-min uzunluk kontrolü yapar, nesne tarafında kontrol yapar
        //[StringLength(100, MinimumLength = 3)] 
        [Column("UrunAdi", TypeName = "nvarchar(100)", Order = 3)] //sütün ismi, tipi ve sırası
        public string Name { get; set; }

        [Range(0.1, 10000, ErrorMessage = "Fiyat 0 ile 10000 arasında olmalı")] //min-max aralığında olmalı
        [DataType(DataType.Currency)] //para birimi formatında gösterir.
        [Phone] //telefon formatında gösterir
        public decimal Price // get-set yazmadan = 0 yazılsaydı nesne tarafında default değer atar. sql tarafından yapmaz
        {
            get { return _price; }
            set
            {
                if (value > 0)
                    _price = value;
                else
                    throw new Exception("Fiyat 0'dan kucuk olamaz");
            }
        }
        public int CategoryId { get; set; } //Foreign Key. EF otomatik olarak foreign olduğunu anlar. Yazmasan otomatik tabloda oluşturulur ama nesne üzerinde sadece id ye erişemezsin. aşağıdaki yapıda erişirsin
        public Category Category { get; set; } //Navigation Property - 1'e çok ilişki
        public ProductDetail ProductDetail { get; set; } //Navigation Property - 1'e 1 ilişki
        public ICollection<Tag> Tags { get; set; } = new List<Tag>(); //migrationda product ve tagdan (ProductTag) oluşan ayrı bir tablo oluşturur. Composit key örneği

        public string Deneme { get; set; }
        public DateTime Deneme3 { get; set; } = DateTime.Now; //nesnenin oluşturma tarihidir. zaman önemliyse onconfiguring kısmında HasDefaultValueSql("GETDATE") kullan
        // public string Deneme2 { get;  } seti olmadığından migratina eklenmez
    }
}
