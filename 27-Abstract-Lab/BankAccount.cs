namespace _27_Abstract_Lab
{
    //bu classtan instance oluşturmayacağımız için abstract tanımlandı
    public abstract class BankAccount
    {
        //Başlangıçta olması gereken değerleri constructora at. Constructor'da olduğu için property setlerini private yap.
        protected BankAccount(string accountNumber, string accountName)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
        }

        public string AccountNumber { get; private set; }
        public string AccountName { get; private set; }
        public double Balance { get; set; }

        //bu metodun davranışı alt sınıflara göre değişeceği için abstract tanımlandı
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Account Holder: {AccountName}, Balance: {Balance}";
        }
    }
}
