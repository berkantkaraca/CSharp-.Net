namespace _08_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region List
            //4.elemana gelince eleman sayısını * 2 yapıyor.bu şekilde 8,16..diye gidiyor.aslında arka planda bir dizidir. 5 eleman verken 1 tane eleman silince dizinin boyutu 8den 4e çekilir
            //dizi listeye göre daha performanslıdır.
            //Generic bir yapıya sahiptir: herhangi veri tipi alabilir
            //Boyut sınırı yoktur
            //Dizide geçerli metotlar burda da geçerlidir.

            List<int> sayilar = new List<int>();
            List<int> sayilar2 = new List<int>() { 10, 20, 30 };

            sayilar.Add(1);
            //sayilar.Remove(1); // data eşleşmesi yapıp siler
            //sayilar.RemoveAt(1); //index numarsına göre siler. 1.indexteki datayı siler
            sayilar.Insert(1, 1); //belirli bir indexe ekleme yapar

            //Console.WriteLine(sayilar[4]); //datayı okumak

            Console.WriteLine("For:");
            for (int i = 0; i < sayilar.Count; i++)
            {
                Console.WriteLine(sayilar[i]);
            }

            Console.WriteLine("Foreach:");
            foreach (var item in sayilar)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Foreach:");
            sayilar.ForEach(item => Console.WriteLine(item));
            #endregion

            #region Tupple
            //dizinin gelişmiş halidir. Birden fazla veriyi tek bir değişkende tutmamızı sağlar.
            var person = (Id: 1, Name: "Fatih", isActive: true);
            #endregion


            #region Example - not hesaplama
            int not;
            string ad, sinif;
            bool dogruMu;

            List<(string Ad, string Sinif, int Not)> ogrenciler = new List<(string Ad, string Sinif, int Not)>(); //tupple liste

            //Öğrenci bilgi girme
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Öğrenci {i + 1}:");

                Console.Write("Adı: ");
                ad = Console.ReadLine();

                Console.Write("Sınıf: ");
                sinif = Console.ReadLine();

                do
                {
                    Console.Write("Not: ");
                    dogruMu = int.TryParse(Console.ReadLine(), out not);
                    Console.WriteLine(dogruMu ? "Giriş işlemi başarılı" : "Hatalı not girişi!");
                } while (!dogruMu);

                ogrenciler.Add((ad, sinif, not));
            }

            //ogrencileri listeleme
            foreach (var ogrenci in ogrenciler)
            {
                Console.WriteLine($"Adı: {ogrenci.Ad}, Sınıf: {ogrenci.Sinif}, Not: {ogrenci.Not}");
            }

            //Notları küçükten büyüğe göre sıralama
            var siraliNotlar = ogrenciler.OrderBy(o => o.Not); //lamda geriye dönüş yapan metotlarda kullanılır
            Console.WriteLine("Sıralanmış Notlar: ");
            foreach (var ogrenci in siraliNotlar)
            {
                Console.WriteLine($"Adı: {ogrenci.Ad}, Sınıf: {ogrenci.Sinif}, Not: {ogrenci.Not}");
            }

            //En yüksek notu bulma
            var enYüksekNot = ogrenciler.OrderByDescending(o => o.Not).FirstOrDefault(); //tersten sıralama yapar ve ilk bulduğunu getirir
            Console.WriteLine($"En yüksek notu alan öğrenci => Adı: {enYüksekNot.Ad}, Sınıf: {enYüksekNot.Sinif}, Not: {enYüksekNot.Not}");
            #endregion
        }
    }
}
