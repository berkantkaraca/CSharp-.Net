namespace _03_Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Operatör: veriler üzerinde çeşitli işlemler yapar

            #region Aritmetik Operatörler
            //Toplama +
            Console.WriteLine(5 + 3);

            //Birleştirme +
            Console.WriteLine("sa" + "as");

            //Fark: 5-4
            Console.WriteLine(5 - 4);

            //Çarpma: 3*5
            Console.WriteLine(3 * 5);

            //Bölme: 8/2
            int g = 5; int h = 6;
            double bolme = (double)g / h; //değişkenlerin biri double olsa tip dönüşümüne gerek yok

            //mod %
            Console.WriteLine(10 % 3);
            #endregion

            #region Atama Op.
            int sayi = 5;
            sayi = sayi + 5;
            sayi += 5; // bu tüm operatçrlerde kullanılır

            //arttırma - azaltma
            sayi = 5;
            int a = sayi++; // a=5 sayi=6
            a = ++sayi; // a=6 sayi=6

            int i = 5;
            int j = ++i + i++ + ++i + i;
            Console.WriteLine(j);
            Console.WriteLine(i);
            #endregion

            #region Karşılaştırma op.
            //Eşitlik
            Console.WriteLine(2 == 2);
            Console.WriteLine(3 == 2);
            Console.WriteLine("1" == "1"); //string de bu işlemde değişmezlik özelliğinden dolayı true döner. eğer nesne karşılaştıracak olsan false döner 

            //Eşitsizlik
            Console.WriteLine(2 != 3);
            Console.WriteLine(2 != 2);
            Console.WriteLine(2 < 3);
            Console.WriteLine(2 <= 3);
            Console.WriteLine(2 > 3);
            Console.WriteLine(2 >= 3);
            #endregion

            #region Mantıksal Kapılar
            bool boolA = true;
            bool boolB = false;
            Console.WriteLine(boolA && boolB); // & yapıldığı zaman ilk ifade de koşul sağlanmıyosa diğer koşullara bakmaz
            Console.WriteLine(boolA || boolB); // | yapıldığı zaman ilk ifade de koşul sağlanmıyosa diğer koşullara bakmaz
            #endregion

            #region Kaçış İfadeleri
            Console.WriteLine("escape\n tab boşluk\t tırnağı kullanmak için \" yap ");
            Console.WriteLine("http:\\\\");
            #endregion
        }
    }
}
