using _41_EntityFramework_LoadingType.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _41_EntityFramework_LoadingType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            #region LazyLoading
            var product = context.Products.Find(2);
            Console.WriteLine($"{product.Id} {product.Category.Name}"); //{product.Category.Name} yazınca extra sorgu atar. join yapmaz

            Console.WriteLine("Tüm product");
            var products = context.Products.ToList();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Category.Name}"); //bu senaryoda her category için ayrı istek gider. o yüzden maliyetli
            }
            #endregion

            #region EagerLoading
            //bildiğimiz join işlemini uygular. sadece 1 join sorgusu atar ve bilgileri çeker. senaryo belliyse eager mantıklı olur.
            Console.WriteLine("Eager");

            //context bildirimi Include ile yapılır
            var result = context.Products.Include(p => p.Category);
            var result2 = context.Products.Include(p => p.Category).ThenInclude(c => c.Name);
            //ard arda Include eklenebilir veya ThenInclude kullan. zincirleme olur burda ThenInclude da artık categorydeki proplara erişiriz. productla ilgili bir bağlantı yapamayız

            foreach (var item in result)
            {
                Console.WriteLine($"[{item.Id} {item.Category.Name}");
            }
            #endregion

            #region ExplicitLoading
            //bilinçli yükleme. ne zaman yükleneceğini ben karar veririm. en tasarruflu yöntem bu. manuel kontrollerde explicit mantıklı olur.
            Console.WriteLine("Explicit");

            //nerden gitiğine göre değişir. category-product mı product-category mı? arasında fark var burda.
            var category = context.Categories.FirstOrDefault(x => x.Id == 1);
            context.Entry(category).Collection(c => c.Products).Load(); //kaetgoride Icollection ilişkiisi olduğundan Collection kullanılır

            //sadece ilgili varlığın bilgileri çekilir
            var products2 = context.Products.FirstOrDefault(x => x.Id == 1);
            context.Entry(products2).Reference(p => p.Category).Load(); //producta ilişki tek o yüzden Reference kullanılır
            #endregion
        }
    }
}
