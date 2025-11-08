namespace _27_Abstract_Lab
{
    public class SavingsAccount : BankAccount
    {
        private double _interestRate = 0.03; //Faiz oranı

        public SavingsAccount(string accountNumber, string accountName) : base(accountNumber, accountName)
        {
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited: {amount} into saving account. Total Balance: {Balance}");
            AddInterest();
        }


        public override void Withdraw(double amount)
        {
            if(Balance - amount >= 0)
            {
                Balance -= amount;
                Console.WriteLine($"Withdraw {amount} from saving account. Total Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal");
            }
        }

        private void AddInterest() //faiz işletiyor
        {
            Balance += Balance * _interestRate;
            Console.WriteLine($"Interest added. Balance: {Balance}");
        }
    }
}
