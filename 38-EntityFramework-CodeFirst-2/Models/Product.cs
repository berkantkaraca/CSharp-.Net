namespace _38_EntityFramework_CodeFirst_2.Models
{
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
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price
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
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
