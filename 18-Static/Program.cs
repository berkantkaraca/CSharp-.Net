namespace _18_Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Static: bir sınıfın, metodun, alanın veya üyenin yalnızca bir örenği olduğunu belirtmek için kullanılır. Nesnenin değil sınıfın bir parçasıdır
            Ornek.Yazdir(); //nesne oluşturulmadan erişildi

            Console.WriteLine(MathHelper.Pi);
            double alan = MathHelper.CalculateCircleArea(15);
            Console.WriteLine(alan);

            string original = "Hello";
            string encrypted = EncryptionHelper.Encrypt(original);
            Console.WriteLine("Orijinal: " + original + " Şifre: " + encrypted + " Çözülmüş: " + EncryptionHelper.Decrypt(encrypted));

            User u1 = new User();
            Console.WriteLine("Total user: " + User.TotalUsers);

            User u2 = new User();
            Console.WriteLine("Total user: " + User.TotalUsers);

            Console.WriteLine(O2.deger); //burda constructor 1 kez çalışır
            Console.WriteLine(O2.deger2); //burada çalışmaz çünkü static constructor sadece 1 kez çalışır

            /*  C#’ta static constructor (statik yapıcı) çalışma mantığı:
                Statik yapıcı sadece bir kere, sınıftan ilk erişim yapıldığında çalışır.
                İlk erişimden sonra tekrar çağrılmaz.
                Bu sayede sınıfın statik alanları ilk kez kullanıma hazır hale getirilir.
            */
        }

        public static class O2
        {
            public static int deger;
            public static int deger2 = 10;

            static O2()
            {
                deger = 10;
                Console.WriteLine("Static");
            }
        }
    }

    //class'ı static yaparsan bu sınıf içinde Deneme gibi static olmayan prop kalamaz.
    //Static yapılan bir class'tan instance oluşturulamaz
    //class ı static yapmak yerine metotları static yazmak daha performanslıdır.
    public /* static */ class Ornek
    {
        public string Deneme { get; set; }
        public static int Deger = 10;

        public static void Yazdir()
        {
            Console.WriteLine("Statik metot");
        }

        public void DenemeInfo()
        {
            Console.WriteLine(Deneme);
        }
    }
}