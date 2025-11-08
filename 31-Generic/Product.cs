namespace _31_Generic
{
    public abstract class Product
    {
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Product name: {Name}, Price: {Price:C}, Quantity: {Quantity}";
        }

        public virtual void IncreaseQuantity(int amount)
        {
            Quantity += amount ;
            Console.WriteLine($"Quantity updated {Quantity} units");
        }

        public virtual void DecreaseQuantity(int amount)
        {
            Quantity -= amount;
            Console.WriteLine($"Quantity updated {Quantity} units");
        }
    }
}
