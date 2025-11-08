namespace _28_Interface.BadExamples
{
    public class SqlDatabase
    {
        public void Create(string name, decimal price, int stok)
        {
            Console.WriteLine($"SqlDatabase e kaydedildi. {name} - {price} {stok}");
        }

        public void Update(string name, decimal price, int stok)
        {
            Console.WriteLine($"SqlDatabase e güncellendi. {name} - {price} {stok}");
        }
    }
}
