using _38_EntityFramework_CodeFirst_2.Contexts;
using _38_EntityFramework_CodeFirst_2.Models;

namespace _38_EntityFramework_CodeFirst_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var product = new Product()
                {
                    Name = "Test Product",
                    Price = 100,
                    Category = new Category()
                    {
                        Name = "Test Kategori"
                    },
                    ProductDetail = new ProductDetail()
                    {
                        Color = "Mavi",
                        Description = "Test Description"
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag
                        {
                            Tag = new Tag { Title = "Yeni" }
                        },
                        new ProductTag
                        {
                            Tag = new Tag { Title = "Kampanya" }
                        }
                    }
                };

                context.Products.Add(product);

                Console.WriteLine(context.SaveChanges() > 0 ? "Başarılı" : "Başarısız");
                Console.ReadLine();
            }
        }
    }
}
