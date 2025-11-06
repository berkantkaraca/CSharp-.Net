namespace _07_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Array
            //aynı veri tipindeki birden çok değeri bir arada tutan yapı
            int[] nums = new int[5];
            int[] numbers2 = new int[] { 1, 2, 3 };

            int[] numbers; //number adında pointer oluşturuldu(stack). adres oluşturulmadı henüz (heap alanı boş)
            numbers = new int[5]; //new ile adresleme yapılır ve heap alanında bir data oluşturur ve referasnı numbers pointer'ına atar

            //heap alanındaki değerlere index numarasıyla erişilir
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            numbers[3] = 4;
            numbers[4] = 5;
            Console.WriteLine(numbers[3]);

            numbers = new int[8]; //heap de 8 boyutlu yeni bir dizi oluşturur ve referansı numbers'a atar. önceki dizi de garbage collector tarafından silinir

            string[] meyveler = { "elma", "armut" }; // new string[] ifadesine gerek kalmadı

            //Not: diziyi büyütme şansın yok. yeni bir referans oluşturman lazım

            for (int i = 0; i < meyveler.Length; i++)
            {
                Console.WriteLine(meyveler[i]);
            }

            Console.WriteLine(new string('*', 10));

            foreach (string meyve in meyveler)
            {
                Console.WriteLine(meyve);
            }

            Console.WriteLine(new string('*', 10));

            int[] sayilar = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < sayilar.Length; i++) // okuma ve yazma işlemi yapar. elemanlara index numarasıyla erişir
            {
                sayilar[i] = sayilar[i] * 2;
            }

            foreach (int sayi in sayilar) //foreach sadece okuma işlemini yapar. yukarıdaki gibi dizinin elemanlarını değiştiremez. elemanları sırasına göre işlem yapar
            {
                Console.WriteLine(sayi);
            }
            #endregion

            #region Multidimensional Arrays
            int[,] matris = new int[3, 3]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Console.WriteLine(matris[1, 2]);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(matris[i, j]);
                }
                Console.WriteLine();
            }
            #endregion

            #region Jagged - Düzensiz Diziler
            int[][] duzensiz = new int[3][]; //3 boyutlu dizi oluşturdu. Ama her boyutuda bir dizi olarak oluşturur
            duzensiz[0] = new int[2];
            duzensiz[1] = new int[4];
            duzensiz[2] = new int[1];

            Console.WriteLine(duzensiz[0][1]);
            #endregion

            #region Array Sınıfı
            string[] ornekDizi = { "İst", "Ank", "Izmir", "Bursa", "Esk", "Konya", "Trab", "Sivas", "Esk" };

            //Sort: Sıralama
            Array.Sort(ornekDizi);
            Array.Sort(ornekDizi, 4, 2); //4. indexten sonraki 2 datayı sıralar
            Console.WriteLine("Sıralı Dizi: (artan sırada sıralar)");
            foreach (var item in ornekDizi)
            {
                Console.WriteLine(item);
            }

            //Reverse: tersine çevirir
            Array.Reverse(ornekDizi);
            Array.Reverse(ornekDizi, 4, 2); //4. indexten sonraki 2 datayı tersine çevirir
            Console.WriteLine("Tersine Dizi:");
            foreach (var item in ornekDizi)
            {
                Console.WriteLine(item);
            }

            //IndexOf: belirtilen değerin dizideki indexini döner
            //LastIndexOf: aynı işlemi sondan başlayarak yapar
            int index = Array.IndexOf(ornekDizi, "İst"); // aramaya 0. indisten itibaren sıralı şekilde başlar. datayı bulamazsa -1 döner
            int index2 = Array.IndexOf(ornekDizi, "İst", 4, 2); //4. indexten aramaya başlar 2 adım sürer
            int index3 = Array.LastIndexOf(ornekDizi, "İst");
            Console.WriteLine(index);
            Console.WriteLine(index2);

            //ındexof ve lastındexof ile dizide aynı eleman var mı?
            int i1 = Array.IndexOf(ornekDizi, "Esk");
            int i2 = Array.LastIndexOf(ornekDizi, "Esk");

            if (i1 != i2)
            {
                Console.WriteLine("Birden fazla var");
            }
            else
            {
                Console.WriteLine("Bir tane var");
            }

            //Clear: silme işlemi. burdaki silme işlemi dizi yok etme şeklinde değil de elemanları null yapar
            Array.Clear(ornekDizi); //hepsi silinir
            Array.Clear(ornekDizi, 4, 2); // 4. indexten sonraki 2 datayı siler
            foreach (var item in ornekDizi)
            {
                Console.WriteLine(item);
            }

            //Copy
            string[] yeniSehirler = new string[4]; //yeni bir dizi oluşturur
            Array.Copy(ornekDizi, yeniSehirler, 4); // 4. iindexe kopyalar
            //Array.Copy(ornekDizi, 3, yeniSehirler, 2, 4); // kopyalamaya 3, yapıştırmaya 2. indexten başla
            foreach (var item in yeniSehirler)
            {
                Console.WriteLine(item);
            }

            // arrayin referansını değiştirerek boyutunu arttırma. Normal şartlarda dizilerin boyutu değişmez.
            Array.Resize(ref ornekDizi, 12); //12 boyutlu yeni bir dizi referansı oluşturur. daha sonra ornekDiziye bu referansı verir
            #endregion
        }
    }
}
