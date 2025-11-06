namespace _15_Metot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SelamVer("Hasan");
            int result = Topla(5, 2) * 2;

            //LogMessage("Thisi is a default log");
            LogMessage("Thisi is a default log", "Warning");
            LogMessage(statuss: "Eror", message: "sa");

            DisplayUserInfo("A");
            DisplayUserInfo("A", 7);

            Topla(5, 2);
            Topla(5, 6, 7);
        }

        //ErişimBelirleyici Niteleyici? GeriDönüşTipi MetotAdı(parametreler?) { }
        private static void SelamVer(string ad)
        {
            Console.WriteLine("Merhaba: " + ad);
        }

        static int Topla1(int n, int m) //default erişim belirteci metotlarda private'dir
        {
            try
            {
                return n + m;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw; //her koşulda ya bir return yada exception fırlatman lazım
            }
        }

        public static void LogMessage(string message, string logLevel = "INFO") //default değeri atanan parametreler en sona yazılır
        {
            Console.WriteLine($"{logLevel} : {message}");
        }

        public static void LogMessage(string message, string logLevel = "INFO", string statuss = "1")
        {
            Console.WriteLine($"{logLevel} : {message}, {statuss}");
        }

        //null geçilebilen parametre
        public static void DisplayUserInfo(string name, int? age = null)
        {
            if (age.HasValue) // age is null
                Console.WriteLine($"{name} is {age} years old");
            else
                Console.WriteLine($"{name} did not provide an age");
        }

        #region Metot Overloading
        //Bir metodun birden fazla kullanım şekli vardır. metot imzası değişir. metot imzası da sadece parametrelerdir
        static int Topla(int n, int m)
        {
            return n + m;
        }

        static int Topla(int n, int m, int l)
        {
            return n + m + l;
        }

        static int Topla(int n, decimal m)
        {
            return n + (int)m;
        }
        #endregion
    }
}
