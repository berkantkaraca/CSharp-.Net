namespace _21_Struct
{
    public class Product
    {
        private static int id = 0;

        public Product(string name, Currency price)
        {
            Price = price;
            Name = name;
            Id = ++id;
        }

        public int Id;
        public string Name{ get; private set; }
        public Currency Price { get; private set; }
    }
}
