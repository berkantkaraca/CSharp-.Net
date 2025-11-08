namespace _27_Abstract_Lab
{
    public class CurrentAccount : BankAccount
    {
        private double _overdraftLimit = 5000;

        public CurrentAccount(string accountNumber, string accountName) : base(accountNumber, accountName)
        {
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount} into current account. Total Balance: {Balance}");
        }

        public override void Withdraw(double amount)
        {
            //-5000 bakiyeye kadar çekebiliriz
            if (Balance - amount >= -_overdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine($"Withdraw {amount} from current account: Total Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Withdrawal exceeds overdraft limit");
            }
        }
    }
}
