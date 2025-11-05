namespace _02_TypeCasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Expliction and Implict Casting
            // Implicit: kapalı-bilinçsiz dönüşüm: küçük boyuttan büyük boyutlu tipe aktarım
            byte data1 = 100;
            int data2 = data1; // Implicit

            int data3 = 100;
            byte data4 = (byte)data3; //yüksekten alçağa gittiği için değere bakmadan byte'ın sınırını geçebilir o yüzden açık dönüşüm yapıldı. data3 1000 olsaydı data4 anlamsız bir sayı atanır ve gereksiz olur çünkü sınır dışına çıktı. data kaybı oluştu

            Console.WriteLine(data4);
            #endregion

            #region Convert
            //veri tiplerini değiştirme sınıfıdır
            string str = "123";
            int number = Convert.ToInt32(str);
            Console.WriteLine(number * 2);

            int number2 = 123;
            Byte resul = Convert.ToByte(number2);

            string str1 = "A";
            char resul1 = Convert.ToChar(number2);

            char chr1 = 'A';
            int result2 = Convert.ToInt32(chr1); // ASCII tablosunda A'nın karşılığını verir
            Console.WriteLine(result2);

            int i1 = 75;
            char result = Convert.ToChar(i1); // ASCII tablosunda 75'in karşılığını verir

            bool b = true;
            int i = Convert.ToInt32(b); // true ise 1 false ise 0 döner

            char c = 'a'; //burda patlar ama string değerde true yada false olsa kabul eder.
            bool r = Convert.ToBoolean(c);
            #endregion

            #region Parse
            //Convertten hızlı çalışır. Ama sadece string bir datayı istediğimiz türe dönüştürürüz.
            string ns = "123";
            int x = int.Parse(ns);
            double d = double.Parse(ns);

            string boool = "True";
            bool bn = bool.Parse(ns);
            #endregion

            #region ToString
            //herhangi bir datayı stringe çevirir
            int data = 123;
            Console.WriteLine(data.ToString());
            Console.WriteLine(2.5.ToString());
            #endregion
        }
    }
}
