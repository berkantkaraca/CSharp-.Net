namespace _31_Generic
{
    public class ElectronicProduct : Product
    {
        public int WarrantPeriod { get; set; }
        public ElectronicProduct(string name, decimal price, int quantity, int warrantPeriod) : base(name, price, quantity)
        {
            WarrantPeriod = warrantPeriod;
        }

        public override string ToString()
        {
            return base.ToString() + $"Warrant Period: {WarrantPeriod}";
        }

        public override void DecreaseQuantity(int amount)
        {
            if(Quantity -  amount >= 0) 
                base.DecreaseQuantity(amount);
            else
                Console.WriteLine("Amount must be smaller than quantity");
        }

        //increse override ederek 0dan küçük olamaz vs eklenebilir
    }
}
