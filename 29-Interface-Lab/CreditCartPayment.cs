namespace _29_Interface_Lab
{
    public class CreditCartPayment : BasePayment
    {
        public string CartNumber { get; set; }
        public string Cvv { get; set; }
        public CreditCartPayment(decimal amount, string cartNumber, string cvv) : base(amount)
        {
            CartNumber = cartNumber;
            Cvv = cvv;
        }

        public override void CancelPayment()
        {
            Console.WriteLine($"Kredi kartinda {Amount} TL ödeme iptal");
        }

        public override void MakePayment()
        {
            Console.WriteLine($"Kredi kartinda {Amount} TL ödendi. Kart: {CartNumber}");
        }
    }
}
