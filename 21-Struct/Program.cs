namespace _21_Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //struct value tipli veri türü tanımlama
            Color color = new Color();
            color.Red= 20;
            color.Green= 130;
            color.Blue= 210;

            color.GetColor();

            List<Product> products = new List<Product>()
            {
                new Product("Kalem", new Currency(150)),
                new Product("Defter", new Currency(150)),
                new Product("Kitap", new Currency(140, "$")),
            };

            foreach (var item in products)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Price.GetCurrency()}");
            }
        }
    }
}