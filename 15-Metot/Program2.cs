namespace _15_Metot
{
    public class Program2
    {
        static void Main2(string[] args)
        {
            #region Params
            int[] nums = { 1, 2, 3 };

            Console.WriteLine(Topla1(nums)); //bizi dizi olması sınırlandırdı. params bunu esnekleştirir.
            Console.WriteLine(Topla2(1, 2, 3, 4)); //istediğin kadar parametre geçebilirsin
            #endregion

            #region Out
            //parametre üzerinden dışarıya data çıkarır. çıkış paramertesidir. içerden dışarıya data gönderir
            double sonuc, bolumdenKalan;
            sonuc = Bolme(15, 2, out bolumdenKalan);
            Console.WriteLine($"15/2: {sonuc}, Kalan: {bolumdenKalan}");
            #endregion

            #region Ref
            int a = 10, b = 12;

            Console.WriteLine($"İşlem öncesi a: {a}, b: {b}");
            Console.WriteLine();

            ToplamDeger(a);
            FarkDeger(ref b);
            Console.WriteLine($"İşlem Sonrası a: {a}, b: {b}");


            int ToplamDeger(int a)//metot içinde yazılan local metotlar
            {
                return a += 10;
            }

            void FarkDeger(ref int b)//metot içinde yazılan local metotlar
            {
                b -= 5;
            }

            #endregion

            #region ref2
            int sayi = 5;
            Console.WriteLine(sayi);

            DegeriDegistir(ref sayi);
            Console.WriteLine(sayi);
            #endregion

            #region Local Metotlar-Fonksiyonlar
            //metot içinde metot tanımlama. public ve static kullanılmaz. yazıldığı fonksiyonunkileri alır. bu metotlara dışarıdan erişilemez. public olsa bile
            int Hesapla(int a)
            {
                return a + 10;
            }
            #endregion
        }

        //metotları yazarken info veren yapı: Topla1(); üstüne mouse getir vs
        /// <summary>
        /// N sayıda değişkeni toplayan metot
        /// </summary>
        /// <param name="sayilar">Birden fazla sayı girişi</param>
        /// <returns>Sayıların toplam değeri</returns>
        public static int Topla1(int[] sayilar)
        {
            int toplam = 0;
            foreach (var item in sayilar)
            {
                toplam += item;
            }

            return toplam;
        }

        public static int Topla2(params int[] sayilar)
        {
            int toplam = 0;
            foreach (var item in sayilar)
            {
                toplam += item;
            }

            return toplam;
        }

        /// <summary>
        /// Bölme işlemini gerçekleştirir
        /// </summary>
        /// <param name="bolunen">Bölünecek Sayı</param>
        /// <param name="bolen">Bölen Sayı</param>
        /// <param name="kalan">Kalan Sayı</param>
        /// <returns>Sonuç</returns>
        public static double Bolme(double bolunen, double bolen, out double kalan)
        {
            kalan = bolunen % bolen;
            return bolunen / bolen;
        }

        public static void DegeriDegistir(ref int x)
        {
            x = x + 10;
        }

        #region BestPractice
        /*  Adlandırma Kuralları
         *  1- Anlamlı isimler: Calculate yerine CalculateTotalPrice
         *  2- Fiil kullanımı: GetCustomer, SaveFile, SendEmail...
         *  3- camelCase ve PascalCase: metotlar PascalCase, değişkenler camelCase
         *  SOLID
        */
        #endregion
    }
}
