namespace _01_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte yas = 23; //yaş değişkeni için byte aralık yeter
            Console.WriteLine("Yaş: " + yas);
            Console.WriteLine("Yaş: {0}", yas); //placeholder - index numarasıyla virgülden sonra eşleşir
            Console.WriteLine($"Yaş: {yas}"); //string interpolation

            #region Primative Veri Tipleri 
            #region Tam sayılar 
            //byte: 0-255 arasında sayı alır, en temel tip
            Console.WriteLine(nameof(Byte)); //nameof runtime'da kullanılır. Aldığı parametrenin class'ını gösterir
            Console.WriteLine($"Alt Limit: {Byte.MinValue,5}"); //5: boşluk bırakır
            Console.WriteLine($"Üst Limit: {Byte.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(Byte)}");

            Console.WriteLine(new string('*', 20)); //new referans tip olduğunu anlatır

            //sByte: işaretlenmiş byte, negatif aralığı var
            Console.WriteLine(nameof(SByte));
            Console.WriteLine($"Alt Limit: {SByte.MinValue,5}");
            Console.WriteLine($"Üst Limit: {SByte.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(Byte)}");

            Console.WriteLine(new string('*', 20));

            //Short
            Console.WriteLine(nameof(Int16)); //short'un class ismi Int16'dır. 2^16. short olarak nameofta kullanamıyoz
            Console.WriteLine($"Alt Limit: {short.MinValue,5}");
            Console.WriteLine($"Üst Limit: {short.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(short)}");

            Console.WriteLine(new string('*', 20));

            //UShort
            Console.WriteLine(nameof(UInt16)); //class ismi UInt16'dır. 2^16
            Console.WriteLine($"Alt Limit: {ushort.MinValue,5}");
            Console.WriteLine($"Üst Limit: {ushort.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(ushort)}");

            Console.WriteLine(new string('*', 20));

            //Int
            Console.WriteLine(nameof(Int32));
            Console.WriteLine($"Alt Limit: {int.MinValue,5}");
            Console.WriteLine($"Üst Limit: {int.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(int)}");
            //23 => bu şekilde tanımlanan sayı default olarak int kabul edilir

            Console.WriteLine(new string('*', 20));

            //UInt
            //veritabanında data kaybını önlemek için uint kullan. id increment olduğu için - değerleri kazanmış olursun
            Console.WriteLine(nameof(UInt32));
            Console.WriteLine($"Alt Limit: {uint.MinValue,5}");
            Console.WriteLine($"Üst Limit: {uint.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(uint)}");

            Console.WriteLine(new string('*', 20));

            //Long
            Console.WriteLine(nameof(Int64));
            Console.WriteLine($"Alt Limit: {long.MinValue,5}");
            Console.WriteLine($"Üst Limit: {long.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(long)}");

            Console.WriteLine(new string('*', 20));

            //ULong
            Console.WriteLine(nameof(UInt64));
            Console.WriteLine($"Alt Limit: {ulong.MinValue,5}");
            Console.WriteLine($"Üst Limit: {ulong.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(ulong)}");

            Console.WriteLine(new string('*', 20));
            #endregion

            #region Ondalıklı Sayılar
            //Float: virgülden sonra 7 basamklı sayıyı destekler
            Console.WriteLine(nameof(Single));
            Console.WriteLine($"Alt Limit: {float.MinValue,5}");
            Console.WriteLine($"Üst Limit: {float.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(float)}");

            Console.WriteLine(new string('*', 20));

            //Double: virgülden sonra 15 basamklı sayıyı destekler
            Console.WriteLine(nameof(Double));
            Console.WriteLine($"Alt Limit: {double.MinValue,5}");
            Console.WriteLine($"Üst Limit: {double.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(double)}");
            //23.8 bu şekilde tanımlanan sayı default olarak double kabul edilir

            Console.WriteLine(new string('*', 20));

            //Decimal: virgülden sonra 28 basamklı sayıyı destekler
            //para birimi, istatistik yapılıyorsa, bilimsel çalışmalarda kullanılır
            Console.WriteLine(nameof(Decimal));
            Console.WriteLine($"Alt Limit: {decimal.MinValue,5}");
            Console.WriteLine($"Üst Limit: {decimal.MaxValue,5}");
            Console.WriteLine($"Boyut: {sizeof(decimal)}");

            Console.WriteLine(new string('*', 20));
            #endregion

            #region Karakterler
            //Char
            Console.WriteLine(nameof(Char));
            Console.WriteLine("Limit: 1");
            Console.WriteLine($"Boyut: {sizeof(Char)}");

            Console.WriteLine(new string('*', 20));

            //String
            Console.WriteLine(nameof(String));

            Console.WriteLine(new string('*', 20));
            #endregion

            #region Bool
            //Char
            Console.WriteLine(nameof(Boolean));
            Console.WriteLine($"Alt Limit: {false}");
            Console.WriteLine($"Üst Limit: {true}");
            Console.WriteLine($"Boyut: {sizeof(Boolean)}");

            Console.WriteLine(new string('*', 20));
            #endregion
            #endregion

            #region Değişken Tanımlama
            //veriTipi degiskenAdi = deger;
            int age = 0;

            if (true)
            {
                Console.WriteLine(age); //dış scopedan erişilebilir
                int age2 = 10;
            }
            // Console.WriteLine(age2); if scopu içinde olduğu için kullanılmaz

            int getScore; //camelCase: değişken isimlendirme kuralı
            void Calculate() { } //PascalCase: metod isimlendirme kuralı

            //int x = 1.2; tip kontrolü vardır bura hata verir

            //float o1 = 2.5; //default double olduğu için hata verir
            float o1 = 2.5f;
            double o2 = 2.5d;
            decimal o3 = 0m;

            //value tipler datayı doğrudn üzerinde taşır
            int sayiX; // default olarak 0 atar, value tipinde olduğu için. bu durum diğer değişkenlerde de böyle. double=> 0, bool=>false, char=>0. string referans tip olduğu için null atanır. adresleme yapılmadığını gösterir
            Console.ReadLine();

            string str = "sa";
            Console.WriteLine(str);
            Console.WriteLine(str.GetHashCode());

            //Stack
            int i1 = 5;
            int i2 = i1; //stackte 2. bir alan oluşturur ve 2 ayrı data oluşur

            //Heap
            string str1 = "merhaba";
            string str2 = str1; //stackteki str1 ve str2 pointerlerı heap alanındaki tek bir yeri referans verir. 2 pointer 1 data vardır


            //Değişmezlik kuralı
            string text = "Fatih"; // referans oluşturur
            Console.WriteLine("Başlangıç: " + text);

            text += "Alkan"; // text değişkeninden başka bir referans oluşturup onu kullanır. maaliyetlidir string bu yüzden.
            Console.WriteLine("Değişiklik Sonrası: " + text);

            string original = "Fatih";
            Console.WriteLine(Object.ReferenceEquals(text, original)); // referansların aynı olup olmadığını gösterir. 
            //stirng yeriine StringBuilder kullan. bu stringi value tip olarak çalıştırır. !!!!!!!!!!!!!!!!!!!!!!
            #endregion

            #region Gelişmiş Veri Tipleri
            //Object: tüm veri tiplerini alabilir. Her şey object sınıfından miras almıştır. Üst sınıfa atama yapmak istediğimiz anda kullanılır
            Object s1 = 1;
            s1 = "sa";

            Object d1 = 1;
            Object d2 = 2.5;
            Object d3 = "sa";
            Object d4 = true;

            //Console.WriteLine(d1 * 2); bu hata verir. Bunun için boxing ve unboxing yapılır
            //Boxing: ilkel veri tipini objecte atar
            //Unboxing: objectten  ilkel veri tipine dönüşüm

            Console.WriteLine((int)d1 * 2); //unboxing
            //Console.WriteLine((int)d3 * 2); //d3 te sting var bu bir hatadır.

            //var: değişkenin hangi türde olduğunu anlar. mousle de1 ve de2nin üzerine bak anlarsın.
            //derleme zamanı kod yazdığımız andır. var bu anda tipi belirler. hata vermez
            //istediğin an kullan, genelde apilerde ne geleceği belli olmadığı için kullanılır
            //derleme zamanında tip ataması yapılır
            var de1 = 5;
            var de2 = 5.2;
            var de3 = "sa";
            var de4 = true;

            Console.WriteLine(de1 * 2);
            // Console.WriteLine(de3 * 2); hata verir strin olduğunu bilir

            //dynamic: çalışma zamanında tip ataması yapılır
            dynamic den1 = 5;
            dynamic den2 = 5.2;
            dynamic den3 = "sa";
            dynamic den4 = true;

            //şuan burdaki türleri bilmiyor o yüzden hata vermez ama çalıştırınca 3 ve 4 hata verir
            Console.WriteLine(den1 * 2);
            Console.WriteLine(den2 * 2);
            //Console.WriteLine(den3 * 2);
            //Console.WriteLine(den4 * 2);
            #endregion

            #region not
            //referans tiplerin boyutu yoktur. primitivlerde vardır. primitivler value tiptir.
            //value tip e direkt bellek alanı değişir
            //referans tiplerde adres değişir
            #endregion

            #region Nullable Tipler
            //int a1 = null; //Value tip olduğu için null atanmaz normalde
            int? a1 = null; //int tipidir, value tiptir ama null geçilebilir yapabiliriz
            Console.WriteLine(a1); //debug modda kontrol et görürsün

            //boş geçince güvenlik şüphesi olabilir. Bunu aşağıdaki gibi bunun datası var mı diye kontrol edilebilir. true- false döner.
            Console.WriteLine(a1.HasValue);

            //datayı görmek içim
            Console.WriteLine(a1.Value);

            //int dd = a1 * 5; 
            int dd = a1.Value * 5; //üstteki satır null olabileceği ve işlem yaptığı için hata verir. yazma işlemleride ToString metodunu kullanarak .Value kullanmadan yazabilir

            int? puan = null;
            int sonuc = puan ?? 50; // puan nulsa 50 atar
            #endregion
        }
    }
}
