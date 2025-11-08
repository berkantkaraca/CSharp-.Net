using _30_BuiltInInterface.Example1;
using _30_BuiltInInterface.Example2;
using _30_BuiltInInterface.Example3;
using _30_BuiltInInterface.Example4;

namespace _30_BuiltInInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Example-1: IEnumarable
            Kitaplık kitaplik = new Kitaplık();
            kitaplik.KitapEkle(new Kitap() { Ad = "a", Yazar = "b" });
            kitaplik.KitapEkle(new Kitap() { Ad = "c", Yazar = "d" });

            //IEnumarable olmasaydı kitaplık.Kitaplar şeklinde yazmam lazımdı fakat bu yapıyla direkt nesneyi verip liste oluşturmadan hallettik
            foreach (var item in kitaplik)
            {
                Console.WriteLine(item.Ad + " " + item.Yazar);

            }
            #endregion

            #region Example-2: ICollection,  IList
            Bookcase2 books = new Bookcase2();
            Console.WriteLine(books.Capacity);
            Console.WriteLine(books.Count);
            Console.WriteLine("*****");
            books.Add(new Book() { Name = "a" });
            books.Add(new Book() { Name = "c" });

            Console.WriteLine(books.Capacity);
            Console.WriteLine(books.Count);
            Console.WriteLine("*****");

            books.Add(new Book() { Name = "a" });
            books.Add(new Book() { Name = "c" });

            Console.WriteLine(books.Capacity);
            Console.WriteLine(books.Count);
            #endregion

            #region Example-3: IComparable, IEquatable, ICloneable, IComparer
            List<string> strings = new List<string>() { "Istanbul", "Ankara", "Rize" };
            strings.Sort();

            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(strings.Contains("Rize"));

            List<Ogrenci> ogrencis = new List<Ogrenci>()
            {
                new Ogrenci() {Ad = "B", Ortalama = 22.5},
                new Ogrenci() {Ad = "A", Ortalama = 72.5},
                new Ogrenci() {Ad = "C", Ortalama = 42.5}
            };
            //ogrencis.Sort();//hata verir. neyi sıralayacağını bilmiyor. ogrenciyi IComparable'dan implement et

            foreach (var s in ogrencis)
            {
                Console.WriteLine(s.Ad + " " + s.Ortalama);
            }

            ogrencis.Sort(new OgrenciOrtalamaKarsilastirici());
            foreach (var s in ogrencis)
            {
                Console.WriteLine(s.Ad + " " + s.Ortalama);
            }

            //Eşitlik kontrolü
            Console.WriteLine(ogrencis.Contains(new Ogrenci() { Ad = "C", Ortalama = 42.5 })); //false döner bunun Containsi IEquatable<Ogrenci> implemente ederek çözersin.

            //Clone
            var o1 = new Ogrenci() { Ad = "s", Ortalama = 42.5 };
            var o2 = (Ogrenci)o1.Clone();

            Console.WriteLine("Esitlik kontrolu: ");
            Console.WriteLine(o1.Equals(o2)); //kendi yazdığımız equal çalışır true döner
            Console.WriteLine(o1 == o2); //referans farklı o yüzden fasle döner
            #endregion

            #region Example-4: IDisposable
            //using işi bitince nesneyi siler
            using (var yazici = new DosyaYazici("ornek.txt"))
            {
                yazici.Yaz("Merhaba");
                //yazici.Dispose(); //using kullandığımız için dispose yazmana gerek yok otomatik kendi çalıştırır
            }
            #endregion
        }
    }
}
