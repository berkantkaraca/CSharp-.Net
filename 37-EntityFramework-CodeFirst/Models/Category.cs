namespace _37_EntityFramework_CodeFirst.Models
{
    public class Category
    {
        //Entity boş constructor tanımlanmasını ister. Eğer parametreli constructor tanımlanırsa boş constructor da tanımlanmalıdır.
        public Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
        
        public int Id { get; set; } // Id gördüğünde PrimaryKey, int görünce de Identity ekler. Id yerine CategoryId yazsada primary key yapardı 
        public string Name { get; set; } //Hiçbir atama yapılmazsa NOT NUll kabul edilir, string? yazıldığında NULL kabul edilir
        public ICollection<Product> Products { get; set; } = new List<Product>(); //Navigation Property. ICollection tanımlama sebebi soyuta dayandırmak

        //İlişkilerde silme işlemi için otomatik olarak cascade delete yapar. Category silindiğinde ilişkili Product'ları da siler.
    }
}
