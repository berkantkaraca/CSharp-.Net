namespace _29_Interface_Lab
{
    //abstract class'ın üzerine çıkabiliriz. IPayment eklendi
    //interface'i implementi burada yazabiliriz. Her sınıf için ortak bir yapı yazılmış olur veya interface'deki metotları abstract olarak tanımlayıp alt sınıflara bırakabilirsin
    public abstract class BasePayment : IPayment
    {
        private decimal _amount;

        protected BasePayment(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (value > 1)
                    _amount = value;
                else
                    throw new ArgumentException("Ödeme miktarı 1'den küçük olamaz");
            }
        }

        public abstract void CancelPayment();
        public abstract void MakePayment();
    }
}
