using System.Diagnostics;
using System.Xml.Linq;

namespace _17_Class_Lab
{
    public class Product
    {
        private double _price; //Encapsulation
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public Product(string name, double price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public string Name { get; private set; }
        public double Price
        {
            get => _price;
            private set {
                if (value < 0)
                    throw new ArgumentException("Fiyat negatif olamaz");
                _price = value; 
            }
        }

        public string Category { get; set; }
        
        public string DisplayInfo()
        {
            return $"Ürün: {Name} Kategori: {Category} Fiyat: {Price:C2}";
        }
    }
}
