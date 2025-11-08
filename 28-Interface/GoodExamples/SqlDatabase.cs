namespace _28_Interface.GoodExamples
{
    public class SqlDatabase : IDatabase
    {
        public void Create(string name, decimal price, int stock)
        {
            Console.WriteLine("Sql ekledi");
        }

        public void Delete(int id)
        {
            Console.WriteLine("Sql sildi");
        }
    }
}
