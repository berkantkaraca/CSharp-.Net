namespace _12_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LIFO
            Stack<int> yigin = new Stack<int>();

            yigin.Push(1); //eleman ekleme
            yigin.Push(2);
            yigin.Push(3);

            yigin.Pop(); // silme

            yigin.Peek(); //TryPeek halide var 

            #region Örnek:  Tarayıcı Geçmişi
            Stack<string> gecmis = new Stack<string>();
            string giris = "";

            while (true)
            {
                Console.WriteLine("1. Ekle");
                Console.WriteLine("2. Listele");
                Console.WriteLine("3. Geri al");
                Console.WriteLine("4. Çık");
                Console.Write("Seçim: ");

                giris = Console.ReadLine();

                switch (giris)
                {
                    case "1":
                        Console.Write("\nGeçmiş bilgisi: ");
                        string gecmisBilgisi = Console.ReadLine();
                        gecmis.Push(gecmisBilgisi);
                        Console.WriteLine("Eklendi");
                        break;

                    case "2":
                        Console.WriteLine("\nGeçmiş Listesi:");
                        foreach (var item in gecmis)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "3":
                        if (gecmis.Count > 0)
                        {
                            string geri = gecmis.Pop();

                            Console.WriteLine($"Geri alınan sayfa: {geri}");
                        }
                        else
                            Console.WriteLine("Geçmiş bulunamadı");
                        break;

                    case "4":
                        Console.WriteLine("Çıkış yapılıyo");
                        return;

                    default:
                        Console.WriteLine("Geçersiz");
                        break;
                }
            }
            #endregion
        }
    }
}
