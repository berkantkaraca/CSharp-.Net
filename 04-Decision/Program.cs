namespace _04_Decision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region if - VKİ hesaplama
            Console.Write("Kilonuz: ");
            double kilo = double.Parse(Console.ReadLine()); //string olduğunu bildiğimiz için parse kullanmak converte göre performanslı

            Console.Write("Boyunuz: ");
            double boy = double.Parse(Console.ReadLine());

            double vki = kilo / (boy * boy);

            if (vki < 18.5)
                Console.WriteLine("Zayıf");
            else if (vki < 24.9)
                Console.WriteLine("Normal");
            else if (vki < 29.9)
                Console.WriteLine("Kilolu");
            else
                Console.WriteLine("Obez");
            #endregion

            #region Ternary if
            Console.WriteLine(30 < 50 ? "Kaldı" : "Geçti");

            Console.Write("Sayı gir: ");
            int sayi = int.Parse(Console.ReadLine());
            Console.WriteLine(sayi > 0 ? "Pozitif" : sayi < 0 ? "Negatif" : "Sıfır"); //ternary de else işlemi
            #endregion

            #region Switch Case
            //eşitlik operasyonlarında daha performanslı. Çünkü sadece ilgili case'e gifiyor. if yapısında else if sorguları çalışacağı için zayıf
            //factory design pattern: switch case bunun bir örneğidir. ne verirsen onu çıkartır.
            Console.Write("Sayı gir (1-7): ");
            int gun = int.Parse(Console.ReadLine());
            switch (gun)
            {
                case 1:
                    Console.WriteLine("Pazartesi");
                    break;
                case 2:
                    Console.WriteLine("Salı");
                    break;

                case 3:
                    Console.WriteLine("Çarşamba");
                    break;

                case 4:
                    Console.WriteLine("Perşembe");
                    break;

                case 5:
                    Console.WriteLine("Cuma");
                    break;

                case 6:
                    Console.WriteLine("Cumartesi");
                    break;

                case 7:
                    Console.WriteLine("Pazar");
                    break;

                default:
                    Console.WriteLine("Hatalı");
                    break;
            }
            #endregion

            #region SwitchCase2
            //switch ile patterm matching: bu haliyle if gibi oldu. baştan tüm koşulları denetleyerek gider bu sefer. ama bunu türleri anlayarak gider. mesela string geldiyse int case'lerine girmez. 
            //örneğin -10 girilse ilk ince ilk sorguyu denetler sonra 2. sorguya geçer. ama string geldiğinde sadece string case'ine gider.
            object veri = 10;
            switch (veri)
            {
                case int gelenSayi when gelenSayi > 0:
                    Console.WriteLine("pozitif tam sayı");
                    break;
                case int gelenSayi when gelenSayi < 0:
                    Console.WriteLine("negatif");
                    break;
                case string:
                    Console.WriteLine("Tanımlanamayan bir tür");
                    break;
                default:
                    break;
            }


            //kısa switch
            Console.WriteLine("İşlem seç: (+,-)");
            char islem = Console.ReadLine()[0]; //string dizi olduğu için yapılabilir
            int s1 = 5, s2 = 6;

            double sonuc = islem switch
            {
                '+' => s1 + s2,
                '-' => s1 - s2,
                _ => double.NaN //default kısmı
            };

            //or mantığı
            int secilenGun = 3;
            switch (secilenGun)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("Haftaiçi");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Haftasonu");
                    break;
                default:
                    Console.WriteLine("Hatalı");
                    break;
            }
            #endregion

            #region örnek

            Console.Write("Seyehat türü (Tek Yön, Gidiş Dönüş): ");
            string wayType = Console.ReadLine();

            Console.Write("Uçuş Sınıfı (Ekonomi, Business, First Class): ");
            string classType = Console.ReadLine();

            Console.Write("Bilet adedi: ");
            int ticketCount = int.Parse(Console.ReadLine());

            Console.Write("Promosyon kodu: ");
            string promo = Console.ReadLine();

            int ekonomi = 500, business = 1000, firstClass = 1500;
            double price = 0;

            if (classType == "Ekonomi")
                price = ekonomi * ticketCount;
            else if (classType == "Business")
                price = business * ticketCount;
            else if (classType == "First Class")
                price = firstClass * ticketCount;
            else
                Console.WriteLine("Hatalı uçuş sınıfı girildi.");

            switch (wayType)
            {
                case "Tek Yön":
                    if (promo == "PROMO15")
                        price *= 0.85;
                    break;

                case "Gidis Dönüs":
                    price *= 2;

                    if (promo == "PROMO15")
                        price *= 0.85;
                    break;
                default:
                    Console.Write("Hatalı Giriş yapıldı.");
                    break;
            }

            Console.Write($"Tutar: {price}");
            #endregion
        }
    }
}
