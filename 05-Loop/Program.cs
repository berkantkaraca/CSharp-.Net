namespace _05_Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 500; i++) // while da arttırma işlemi blok içinde yazıldığı için for, while'dan daha hızlı.
            {
                Console.WriteLine(i);
            }

            while (1 > 2)
            {

            }

            //şifre sorulma aşamasında do-while kullanmak mantıklı
            string sifre;
            do
            {
                Console.WriteLine("Şifre: ");
                sifre = Console.ReadLine();
            } while (sifre != "1234");


            //Jump 
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                    break; //döngü dışına çıkarak akışı bir sonraki ifadeye yönlendirir
                Console.WriteLine(i);
            }

            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                    continue; //o anki iterasyonu atlayarak bir sonraki iterasyona geçer
                Console.WriteLine(i);
            }

            //goto: threadi yoran bir işlemdir genelde kullanılmaz. Okunabilirlik de azalır.
            int sayac = 0;
            Start: //pointer
            if (sayac < 5)
            {
                Console.WriteLine(sayac);
                sayac++;
                goto Start;
            }

            int[] sayilar = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < sayilar.Length; i++) //for okuma ve yazma işlemi yapar. elemanlara index numarasıyla erişir
            {
                sayilar[i] = sayilar[i] * 2;
            }

            foreach (int sayi in sayilar) //foreach sadece okuma işlemini yapar. yukarıdaki gibi dizinin elemanlarını değiştiremez. elemanları sırasına göre işlem yapar
            {
                Console.WriteLine(sayi);
            }
        }
    }
}
