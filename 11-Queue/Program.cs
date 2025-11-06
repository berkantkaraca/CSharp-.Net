namespace _11_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FIFO prensibiyle çalışır
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("a"); //kuyruğun sonuna ekler
            queue.Enqueue("b");

            string ilkEleman = queue.Dequeue(); //kuyruğun en başındakini çıkartır ve döndürür
            string bas = queue.Peek(); //kuyruktaki ilk elemanı çıkarmadan döndürür

            #region Örnek: Çağrı Sistemi
            Queue<string> cagriKuyrugu = new Queue<string>();
            string giris = "";

            while (true)
            {
                Console.WriteLine("1. Çağrı Ekle");
                Console.WriteLine("2. Çağrı Listele");
                Console.WriteLine("3. Çağrı İşle");
                Console.WriteLine("4. Çık");
                Console.Write("Seçim: ");

                giris = Console.ReadLine();

                switch (giris)
                {
                    case "1":
                        Console.Write("\nÇağrı bilgisi: ");
                        string cagrıBilgisi = Console.ReadLine();
                        cagriKuyrugu.Enqueue(cagrıBilgisi);
                        Console.WriteLine("Çağrı kuyruğa eklendi");
                        break;

                    case "2":
                        Console.WriteLine("\nKuyrukta bekleyen çağrılar:");
                        foreach (var cagrı in cagriKuyrugu)
                        {
                            Console.WriteLine(cagrı);
                        }
                        break;

                    case "3":
                        if (cagriKuyrugu.Count > 0)
                        {
                            string islenecekCagri = cagriKuyrugu.Dequeue();
                            string siradakiCagri = cagriKuyrugu.Peek(); // sonraki çağrı kalmazsa exception fırlatır

                            Console.WriteLine($"İşlenecek çağrı: {islenecekCagri}, Sıradaki çağrı: {siradakiCagri}");
                        }
                        else
                            Console.WriteLine("İşlenecek çağrı bulunamadı");
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
