namespace _33_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Delegate: içerisinde metot referansı tutabilen türlerdir. Referans tipli bir yapıdır
            //Delegate'in içine aynı geri dönüş ve parametreye sahip metotlar verilir
            //Abonelik türü delegate örneğidir. Hangi kanallardan bildirim almak istiyosa onu seçtirirsin. seçtiklerini delegate olarak eklersin

            numDelegate numDelegate = new numDelegate(Sum); //tekli delegate
            numDelegate += Substract; //multidelegate, -= ile de çıkarırsın
            numDelegate(10, 5); //hem toplamı hemde fark metodunu çalıştırır. Eklenen sıraya göre çalışır

            // hazır delegateler:
            // Predicate: giriş önemli değil ama dönüş tipi boolendır
            // Func: geriye değer dönen metotları saklar
            // Action: geriye değer döndürmeyen delegateleri saklar
            Action<int, int> action = Sum; //geriye void dönen 2 parametreli fonksiyonu ekledik
            action += Substract;
            action(10, 10);

            Func<int, int, int> func = Sum2; //son parametre çıkış tipidir. 2 int parametre girecek. çıkışı int olcak
            func += Substract2;
            func(10, 20);
            func = (a, b) => a * b; //lambda ile çarpma işlemi ekledik
            func += Bolme;

            int Topla(int x, int y) => x + y;
            Func<int, int, int> func2 = (x, y) => x + y; //üst satırla aynı işi yapar

            bool isEven(int number) => number % 2 == 0; //lokal fonksiyon
            Func<int, bool> iseven = x => x % 2 == 0; //üst satırla aynı işi yapar

            ////Where fonksinu da buna benzer şekilde çalışır
            ////numbers.Where()
        }

        //Delegate tanımlama
        public delegate void numDelegate(int a, int b);

        public static void Sum(int a, int b)
        {
            Console.WriteLine("Toplam: " + (a + b));
        }

        public static void Substract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        public static int Sum2(int a, int b)
        {
            return a + b;
        }

        public static int Substract2(int a, int b)
        {
            return a - b;
        }

        public static int Bolme(int a, int b) => a / b;
    }
}
