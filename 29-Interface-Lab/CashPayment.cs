namespace _29_Interface_Lab
{
    //Bir üstü olan abstract'tan kalıtım alınır
    public class CashPayment : BasePayment
    {
        public CashPayment(decimal amount) : base(amount)
        {
        }

        public override void CancelPayment()
        {
            Console.WriteLine($"Nakit ödeme iptal");
        }

        public override void MakePayment()
        {
            Console.WriteLine($"Nakit {Amount} TL ödendi");
        }
    }
}
