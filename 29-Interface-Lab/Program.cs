namespace _29_Interface_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ödeme Sistemi");

            Console.Write("Tutar:");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Yöntem (1-kk, 2-havale:");
            string choice = Console.ReadLine();

            //IPayment veya basepayment ile listeye eklenebilir. loose coupling uygulanmış olur. payment değişkenine ne gelirse o türden tütar
            BasePayment payment = null;

            switch (choice)
            {
                case "1":
                    Console.Write("Kart No: ");
                    string cartNo = Console.ReadLine();

                    Console.Write("Cvv: ");
                    string cvv = Console.ReadLine();

                    payment = new CreditCartPayment(amount, cartNo, cvv);
                    break;

                case "2":
                    payment = new CashPayment(amount);
                    break;

                default:
                    break;
            }

            Console.WriteLine("İşlem yapılıyor");
            payment.MakePayment(); //loose coupling uygulanmış olur. payment değişkenine ne gelirse o türden metot çalışır birdaha uğraşmazsın

            Console.WriteLine("İptal edilsin mi: (E/H)");
            string cancel = Console.ReadLine();

            if (cancel.Equals("E"))
                payment.CancelPayment();

            //Loose coupling: interface veya abstract ile gerçekleştirilebilir. İlgili nesneye göre değil. genele göre işlem yapıp sadece hepsini ilgili abstract veya interface'te tutmak lazım.
        }
    }
}
