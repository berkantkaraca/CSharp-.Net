using _37_EntityFramework_CodeFirst.Contexts;
using _37_EntityFramework_CodeFirst.Models;

namespace _37_EntityFramework_CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PMC komutları (Microsoft.EntityFrameworkCore.Tools yüklü olmalı)
            //Add-Migration InitialCreate //ilk migration ı oluşturur
            //Update-Database //veritabanını oluşturur
            //Remove-Migration //son migration ı siler

            // using işi bitince dispose işlemi yapar
            using (AppDbContext context = new AppDbContext())
            {
                #region Add
                var cat1 = new Category("Kalemler");

                context.Add(cat1); //object alır. kendi içinde cast eder
                context.Categories.Add(cat1); //Model bekler. Add işleminide varlığı Added olarak işler ve izlemye alır (işaretleme yapıldı). EF'nin yavaş olma sebebi de bu. Sorguyu sql'e bu aşamada göndermiyor. Bellekte tutuyor. SaveChanges dediğimizde hepsini tek seferde sql e gönderiyor.
                                              //5 işlemi eklerken 3.de hata alırsa ilk eklediklerini geri alır ve database de değişiklik yapmaz.Transaction işlemi yapar.

                var cat2 = new Category("Kitaplar")
                {
                    Products = new List<Product>()
                    {
                        new Product("Kitap1",350),
                        new Product("Kitap2", 300),
                        new Product("Kitap3", 325),
                    }
                };
                context.Categories.Add(cat2);

                var product1 = new Product("Kalem1", 50, 2);
                context.Products.Add(product1);

                var cat3 = context.Categories.Find(1); //find primary key üzerinden arama yapar. İlk önce cachedeki listeye bakar yoksa sql den çeker. 
                var product2 = new Product("Kalem3", 43, cat3);
                context.Products.Add(product2);
                #endregion

                #region Update
                var product3 = context.Products.Find(6); // state UNCHANGED
                product3.Price = 11; //state MODIFIED olur
                context.Update(product3); // Bunu yazmaya gerek yok. Çünkü context nesnesi izliyor. Değişiklikleri algılar. Modified olduğu için savechanges ile update sorgusu gönderir.
                #endregion

                #region Remove
                var product4 = context.Products.Find(6);
                context.Products.Remove(product4);

                var cat = context.Categories.Find(2);
                var product5 = new Product() //var product5 = context.Products.Find(5);
                {
                    Id = 5,
                    Name = "Kalem1",
                    Price = 50,
                    CategoryId = 1,
                    Category = cat
                };
                //Veritabanındaki kaydın aynısını oluşturduk. Takip edilmeyen bir nesneydi. Remove fonksiyonunda Detached durumunda state Unchanged yapar ve takibe alır. Silme işleminde de Deleted işaretler ve savechangfes ile silinir.
                context.Products.Remove(product5);
                context.Remove(product5); //böyle de yazılabilir

                var product6 = new Product()
                {
                    Id = 3 //Id tekil olduğu için diğer değerler olmasada silme işlemini gerçekleştirilir.
                };
                context.Products.Remove(product6);
                #endregion

                #region Relations
                context.Tag.AddRange(
                    new Tag { Title = "Yeni" },
                    new Tag { Title = "Kampanya" },
                    new Tag { Title = "Indirim" });

                var product7 = new Product("Defter", 75, 1)
                {
                    Tags = context.Tag.Where(t => t.Title == "Yeni" || t.Title == "Kampanya").ToList()
                };
                context.Products.Add(product7);

                var tag1 = new Tag { Title = "Yeni" }; //diyip yukarıdaki gibi de ekleyebilirdik.

                var tag2 = context.Tag.FirstOrDefault(t => t.Title == "Indirim");
                var product8 = context.Products.FirstOrDefault(p => p.Name == "Kitap2");
                product8.Tags.Add(tag2); //listeye ekledik. veritabanına ekler yinede

                //Hata verir: 
                foreach (var item in context.ProductTag.ToList())
                {
                    Console.WriteLine(item.TagId + " " + item.ProductId);
                }
                #endregion

                #region IQueryable And IEnumerable
                //IEnum => databaseden tüm veriyi çekip belleğe alır sonra bellekte işlem yapıp döner
                //IQuery => her seferinde sorguyu olduğu gibi direkt databese e atar çalıştırıp döndürür

                //IQueryable dönenler içinde expression ister. (where içindeki p => p.Id > 0 bir expressiondır)
                context.Products.Where(p => p.Id > 0).ToList();

                //IEnumerable dönenler içinde func ister. (ToList dan sonra p => p.Id > 0 bir func dır)
                context.Products.ToList().Where(p => p.Id > 0).ToList();

                var products = context.Products.Where(x => x.Id > 0); //IQueryable döner
                foreach (var item in products) //sorgu burada çalışır
                {
                    Console.WriteLine(item.Name);
                }

                var products2 = context.Products.Where(x => x.Id > 0).ToList(); //IEnumerable döner. ToList ile belleğe alır. Sorgu IEnumable a dönüştüğünde gerçekleşir aslında
                foreach (var item in products2)
                {
                    Console.WriteLine(item.Name);
                }

                //ToList'den gelen dataya select işlemi uygular. Select işlemini bellekte uygular.
                var products3 = context.Products.Where(x => x.Id > 0).ToList().Select( x => new { Adi = x.Name, Fiyat = x.Price } );

                var products4 = context.Products.Where(x => x.Id > 0)
                    .AsEnumerable() //tolist yerine direkt enuma geçirebilir
                    .Select(
                        x => new { Adi = x.Name, Fiyat = x.Price }
                    );
                //pagination'da bunu düşün.tüm datayı getirip mi işlem yapıcan. yoksa her seferinde mi istek atıcan
                #endregion

                Console.WriteLine(context.SaveChanges() > 0 ? "Başarılı" : "Başarısız"); //Sorgu SaveChanges koduyla gönderilir
                Console.ReadLine();
            }
        }
    }
}
