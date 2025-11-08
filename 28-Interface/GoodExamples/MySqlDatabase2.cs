namespace _28_Interface.GoodExamples
{
    public class MySqlDatabase2 : IDatabase
    {
        public void Create(string name, decimal price, int stock)
        {
            Console.WriteLine("MySql ekledi");
        }

        public void Delete(int id)
        {
            Console.WriteLine("MySql sildi");
        }
    }
}
