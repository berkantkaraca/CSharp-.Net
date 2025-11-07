namespace _19_Extension
{
    internal class Program
    {
        //Hazır olan bir sınıfı geliştrimek için kullanılır. 
        //Küçük geliştirmeler için extension, büyük geliştirmelerde kalıtım uygula
        static void Main(string[] args)
        {
            string selam = "hello";

            Console.WriteLine(selam.ReverseString());
            Console.WriteLine(selam.CapitalizeFirstLetter());

            try
            {
                int x = int.Parse(selam);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetFriendlyMessage());
            }
        }
    }
}