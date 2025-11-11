using _39_EntityFramework_State.Models;
using _39_EntityFramework_State.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _39_EntityFramework_State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Entity State: EF Core'un bir entity'nin durumunu izlemek içinn kullandığı bir mekanizmadır. EntityState olarak isimlendirilen bir enum üzerinden çalışır. Bu enum entity'nin dbcontext içinde nasıl ele alınacağını tanımlar. Eklenecek mi? Güncellenecek mi? vb.
            //Varlığın ne yapacağına karar verir

            /*
             * Detached => Bağlantısız (Henüz veritabanına işlenmemiş veri)
             * Unchanged => Değişmemiş (Varlık veritabanına tanımla ama işlem yapılmamış)
             * Modified => Değiştirilmiş/Güncellenmiş
             * Deleted => Silinmiş
             * Added => Eklenmiş
             * 
             * Detached dışındakiler ef tarafından takip edilir
             */

            using AppDbContext context = new AppDbContext();

            // Bu context üzerinden yapılan işlemler takip edilmez. AsNoTrackinge gerek yok
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var author = new Author { FirstName = "Peyami", LastName = "Safa" };
            Console.WriteLine(context.Entry(author).State); //databese'e eklenmediğinden detached

            //context.Add(author); //state added olarak güncellenir. savechanges ile artık veritabanına gönderir
            context.Entry(author).State = EntityState.Added; //add metodu kullanmadık ama manuel olarak state i added yaptık. savechanges ile veritabanına gönderilir
            Console.WriteLine(context.Entry(author).State); //added

            author.LastName = "Sefa2"; //state hala added olarak kalır. çünkü ekleme işlemi yapılacak. varlık henüz veritabanına eklenmedi o yüzden modified olmaz
            Console.WriteLine(context.Entry(author).State);

            /**************************************************************************/

            var author2 = context.Authors.FirstOrDefault(x => x.FirstName == "Peyami");
            Console.WriteLine(context.Entry(author2).State); //Unchanged

            author2.FirstName = "P2";
            Console.WriteLine(context.Entry(author2).State); //modified

            context.Entry(author2).State = EntityState.Added;
            Console.WriteLine(context.Entry(author2).State); //added

            author2.LastName = "Sefa2"; 
            Console.WriteLine(context.Entry(author2).State); //added. added olduktan sonra değişiklij işleminde durum değişmez

            /**************************************************************************/

            var author3 = context.Authors.FirstOrDefault(x => x.FirstName == "Peyami");
            Console.WriteLine(context.Entry(author3).State); //Unchanged

            author3.FirstName = "P2";
            Console.WriteLine(context.Entry(author3).State); //modified

            context.Entry(author3).State = EntityState.Added;
            Console.WriteLine(context.Entry(author3).State); //added

            author3.LastName = "Sefa2";
            Console.WriteLine(context.Entry(author3).State); //added

            context.Entry(author3).State = EntityState.Detached; //Savechanden önce detached yapınca veritabanı etkilenmez

            context.SaveChanges();

            /**************************************************************************/

            var author4 = context.Authors.FirstOrDefault(x => x.FirstName == "Peyami");
            Console.WriteLine(context.Entry(author4).State); //Unchanged

            author4.FirstName = "P2";
            Console.WriteLine(context.Entry(author4).State); //modified

            context.Entry(author4).State = EntityState.Added;
            Console.WriteLine(context.Entry(author4).State); //added

            author4.LastName = "Sefa2";
            Console.WriteLine(context.Entry(author4).State); //added

            context.SaveChanges();

            Console.WriteLine(context.Entry(author4).State); // takip edilen varlık savechangeden sonra durumu UNCHANGED olur.

            /**************************************************************************/

            var author5 = context.Authors.FirstOrDefault(x => x.FirstName == "Peyami");
            Console.WriteLine(context.Entry(author5).State); //unchanged

            context.Entry(author5).State = EntityState.Deleted;
            Console.WriteLine(context.Entry(author5).State); //deleted

            context.SaveChanges();

            Console.WriteLine(context.Entry(author5).State); // silinen varlığı Detached yapar

            /*  SaveChanges sonrası durumlar:
             * Added ve Updated => Unchancged
             * Deleted => Detached, dbcontexten kaldırır
             */

            /**************************************************************************/

            //AsNoTracking ile veritabanından çekilen veriler dbcontext tarafından takip edilmez. Dolayısıyla state detached olur. Sadece okuma işlemlerinde performans artırmak için kullanılır.
            var books = context.Books.AsNoTracking().ToList();

            foreach (var item in books)
            {
                if (item.Id == 2)
                {
                    //AsNoTracking ile çekilen veriyi update etmek için önce dbcontext e eklememiz gerekir
                    item.Title = "Updated Title";
                    context.Update(item);

                    //2. yol:
                    context.Attach(item); // Attach: Takibe (explicit olarak) almaya başlar. Durum unchanged olur.
                    Console.WriteLine(context.Entry(item).State); //unchanged

                    item.Title = "Updated Title 2"; // unchanged olan varlık değiştirildiğinde state modified olur
                    Console.WriteLine(context.Entry(item).State); //modified
                }

                Console.WriteLine(context.Entry(item).State);
            }

            var books2 = context.Books.ToList();
            foreach (var item in books2)
            {
                Console.WriteLine(context.Entry(item).State);
            }

            //Native SQL Yazma
            var result = context.Books.FromSqlRaw("SELECT * FROM Books WHERE Id > 1").ToList();

            var res = context.Books.FromSqlInterpolated($"SELECT * FROM Books WHERE Id > {1}");

            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(context.Entry(item).State); // FromSqlRaw ile çekilen verilerde dbcontext tarafından takip edilir. State unchanged olur
            }

            //ExecuteSqlRaw
            //savechange gerek yok direkt sorgu atar
            //Stored Procedure çağırma işlemini buradan yapabiliriz
            //ExecuteSqlRaw 'da state takibi yoktur
            var result2 = context.Database.ExecuteSqlRaw("UPDATE Books Set Title = {0} WHERE ID = 2", "Deneme");
        }
    }
}
