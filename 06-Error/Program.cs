namespace _06_Error
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  3 tip hata var:
             *  Derleme Zamanı Hataları (Compile-time Errors): Program kodu derlenmeden önce yani program çalıştırılmadan önce ortaya çıkar genelde syntax hatalarıdır.
             *  int sayi = "1"; //derleme hatası

             *  Mantıksal Hatalar (Logical Errors): Program düzgün bir şekilde derlenir ve çalışır ama algoritmadan kaynaklı hatalardır. Yazılımcı kaynaklıdır.

             *  Çalışma Zamanı Hataları (Run-time Errors): Program derlendikten sonra çalıştırma sırasında meydana gelen hatalardır. try-catch ile hallolur
             *  
             * Hata alınca db connection açıksa kapatılmalı ve session varsa onu kaybetmemeye çalışmalıyız.
             */

            Console.Write("Sayı: ");
            string sayi = Console.ReadLine();

            //try: hata gelmesi muhtemel kodlar yazılır. kodu takip ettiği için gereksiz hata gelmeyecek kısımlar yazılmamalı. performansı düşürür.
            //catch: hata yakalandığında ne yapılacağı yazılır
            //finally: hata olsun veya olmasın çalıştırılacak kodlar yazılır. genelde veritabanı bağlantısı kapatma gibi işlemler için kullanılır
            try
            {
                int donusenSayi = int.Parse(sayi);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Numeric ifade gir" + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Daha küçük bir sayı gir" + ex.Message); //integer aralığının üstünde bir sayı girebilir
            }
            catch (Exception ex) //catch'lerde en geneli en son yazmamız lazım. bunu ilk sıraya yazsam tüm hataları kapsayacağı için diğerlerine giremez
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Her türlü çalışır.");
            }

            //when kullanımı
            try
            {
                int numberWhen = int.Parse("bşr");
            }
            catch (FormatException ex) when (ex.Message.Contains("Input string"))
            {
                Console.WriteLine("Giriş formatı hatalı: " + ex.Message);
            } 
            catch (FormatException ex) // when kullanılmazsa tüm format hatalarını yakalar. Eğer bu catch'i yazmazsan ve when sağlanmazsa hata yakalanmaz. Hata fırlatılır.
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.Write("Yaş: ");
                int age = int.Parse(Console.ReadLine());

                if (age < 18)
                    throw new ArgumentException("Yaş 18'den küçük olamaz");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format Hatası: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Boyut Hatası" + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //bu şekilde de genelde yakalıyıp mesajı özelleştirebilirsin
            try
            {
                Console.Write("Yaş: ");
                int age = int.Parse(Console.ReadLine());

                if (age < 18)
                    throw new ArgumentException("Yaş 18'den küçük olamaz");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Yaş 18'den küçük olamaz");
            }

            string input = "123";
            int number;
            bool success = int.TryParse(input, out number); //dönüşüm yapılırsa fonk true döner ve ilgili değer number değişkenine yazılır. out keywordu bir fonksiyondan değişkeni dışarı gönderir

            if (success)
            {
                Console.WriteLine("Başarılı: " + number);
            }
            else
            {
                Console.WriteLine("Başarısız: " + number); // input 123a olsaydı default değer 0 olduığu için number 0 olurdu
            }

            #region örnek
            string username = "", password = "";
            int balance = 100;
            int money;

            while (true)
            {
                Console.Write("Kullanıcı Adı: ");
                username = Console.ReadLine();

                Console.Write("Şifre: ");
                password = Console.ReadLine();

                try
                {
                    if (username == "admin" & password == "1234")
                        break;
                    else
                        throw new ArgumentException("Kullanıcı adı veya şifre hatalı!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Kullanıcı adı veya şifre hatalı!");
                }
            }

            do
            {
                Console.WriteLine("\n1- Bakiye Sorgulama");
                Console.WriteLine("2- Para Yatırma");
                Console.WriteLine("3- Para Çekme");
                Console.WriteLine("4- Çıkış Yap");
                
                Console.Write("İşlemi seçiniz:");
               int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine($"Bakiyeniz: {balance}");
                        break;

                    case 2:
                        Console.Write("Yatırılacak Tutar: ");

                        bool isSuccess = int.TryParse(Console.ReadLine(), out money);

                        if (isSuccess)
                        {
                            if (money < 0)
                            {
                                Console.WriteLine("Yatırılacak tutar negatif olamaz.");
                                break;
                            }
                            balance += money;
                            Console.WriteLine("Yeni Bakiye : " + balance);
                        }
                        else
                        {
                            Console.WriteLine("Para Yatırılamadı");
                        }
                        break;

                    case 3:
                        Console.Write("Çekilecek Tutar: ");
                        money = int.Parse(Console.ReadLine());

                        if (money < 0)
                        {
                            Console.WriteLine("Lütfen pozitif değer girin");
                            break;
                        }
                        else if (money > balance)
                        {
                            Console.WriteLine("Hesabınızda yeterli bakiye bulunmamaktadır");
                            break;
                        }
                        else
                        {
                            balance -= money;
                            Console.WriteLine("Yeni Bakiye : " + balance);
                        }
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Hatalı Tuşlama Yapıldı.");
                        break;
                }
            } while (true);
            #endregion
        }
    }
}
