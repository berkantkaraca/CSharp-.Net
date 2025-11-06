namespace _10_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Liste çeşitidir. key-value çiftlerini saklar. iterasyona göre hızlı çalışır.
            Dictionary<int, string> ogrenciler = new Dictionary<int, string>();

            ogrenciler.Add(1, "Berkant");
            ogrenciler.Add(2, "Karaca");

            ogrenciler.Remove(2);

            ogrenciler.ContainsKey(2); //2 numaralı key'e sahip biri var mı
            ogrenciler.ContainsValue("Berkant"); //listede berkant adında biri var mı

            Console.WriteLine(ogrenciler[1]);

            string isim;
            if (ogrenciler.TryGetValue(1, out isim))//bool döner. 1 key varsa isime değerini atar. tryparse gibi
            {
                Console.WriteLine(isim);
            }

            Dictionary<string, int> ogrenciNotlari = new Dictionary<string, int>();
            string giris = "";

            while (true)
            {
                Console.WriteLine("1. Not Ekle");
                Console.WriteLine("2. Not Listele");
                Console.WriteLine("3. Not Güncelle");
                Console.WriteLine("4. Not sil");
                Console.WriteLine("5. Çık");
                Console.Write("Seçim: ");

                //Console.Write(@"
                //1. Not Ekle
                //2. Not Listele
                //3. Not Güncelle
                //4. Not Sil
                //5. Çık
                //Seçim: ");

                giris = Console.ReadLine();

                switch (giris)
                {
                    case "1":
                        ogrenciStart:
                        Console.Write("\nAd: ");
                        string ad = Console.ReadLine();

                        Console.Write("Not: ");
                        int not = int.Parse(Console.ReadLine());

                        if (ogrenciNotlari.ContainsKey(ad))
                        {
                            Console.WriteLine("Öğrenci bilgisi mevcut");
                            goto ogrenciStart;
                        }

                        ogrenciNotlari.Add(ad, not);
                        Console.WriteLine("Öğrenci bilgisi eklendi");
                        break;

                    case "2":
                        Console.WriteLine("\nÖğrenci Notları:");
                        foreach (var ogrenci in ogrenciNotlari)
                        {
                            Console.WriteLine($"Ad: {ogrenci.Key}, Not: {ogrenci.Value}");
                        }
                        break;

                    case "3":
                        Console.Write("\nGüncellenecek Ad: ");
                        string guncelAd = Console.ReadLine();

                        if (ogrenciNotlari.ContainsKey(guncelAd))
                        {
                            Console.Write("Güncel Not: ");
                            int guncelNot = int.Parse(Console.ReadLine());
                            ogrenciNotlari[guncelAd] = guncelNot;
                            Console.WriteLine("Öğrenci bilgisi güncellendi");
                        }
                        else
                            Console.WriteLine("Öğrenci bilgisi bulunamadı");
                        break;

                    case "4":
                        Console.Write("\nSilinecek Ad: ");
                        string silinecekAd = Console.ReadLine();

                        if (ogrenciNotlari.Remove(silinecekAd))
                        {
                            Console.WriteLine("Öğrenci bilgisi silindi");
                        }
                        else
                            Console.WriteLine("Öğrenci bilgisi bulunamadı");
                        break;

                    case "5":
                        Console.WriteLine("Çıkış yapılıyo");
                        return;

                    default:
                        Console.WriteLine("Geçersiz");
                        break;
                }
            }
        }
    }
}
