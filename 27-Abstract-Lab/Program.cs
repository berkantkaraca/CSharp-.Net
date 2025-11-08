namespace _27_Abstract_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fatihSavings = new SavingsAccount("SA123", "Fatih Alkan");
            fatihSavings.Deposit(5000);
            fatihSavings.Withdraw(2000);
            fatihSavings.Withdraw(6000);
            Console.WriteLine(fatihSavings);

            Console.WriteLine("***************************");

            var fatihCurrents = new CurrentAccount("CA543", "Fatih Alkan");
            fatihCurrents.Deposit(5000);
            fatihCurrents.Withdraw(7000);
            Console.WriteLine(fatihCurrents);
        }
    }
}
