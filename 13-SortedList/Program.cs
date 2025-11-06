namespace _13_SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //key-value çiftlerine göre sıralı bir şekilde data saklar.
            SortedList<int, string> sinif = new SortedList<int, string>();
            sinif.Add(3, "a"); //tryadd var
            sinif.Add(1, "b");
            sinif.Add(2, "c");
            //sinif.Add(2, "csda"); //aynı keye air başka kayıt eklenemez. hata verir.
            sinif.Add(5, "d");

            sinif.Remove(5);

            foreach (var item in sinif)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}
