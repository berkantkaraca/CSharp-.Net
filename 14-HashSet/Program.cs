namespace _14_HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //benzersiz elemanları tutar
            //arama senaryolarında performanslı şekilde çalışır
            HashSet<string> set = new HashSet<string>();

            set.Add("a");
            set.Add("a");//aynı datayı eklemeye çalıştığında hata vermez ama set içine de eklemez
            set.Add("b");

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
