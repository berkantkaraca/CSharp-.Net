namespace _28_Interface.BadExamples
{
    public class MySqlDatabase
    {
        public void Add(string name, double price, int stok)
        {
            Console.WriteLine($"MySqlDatabase e kaydedildi. {name} - {price} {stok}");
        }

        public void Modified(string name, decimal price, int stok)
        {
            Console.WriteLine($"MySqlDatabase e güncellendi. {name} - {price} {stok}");
        }
    }
}
