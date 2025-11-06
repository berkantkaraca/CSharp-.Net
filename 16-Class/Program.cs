using _16_OOP_Class;

namespace _16_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car mercedes = new Car("Mercedes", 40); //Instance (örnekleme)
            //mercedes.Brand = "TOGG";
            Console.WriteLine(mercedes.Brand);
            mercedes.Number = "123XA1";
            //Console.WriteLine(mercedes.Number);

            Car car1 = new Car() { Model = "A6", Year = 2025, Fuel = 20, Number = "X101" };
            car1.GetInformation();

            Car car2 = new Car("BMW", 40);
            car2.Year = 2025;
            car2.Number = "BM101";
            car2.GetInformation();

            Car car3 = new Car("TOGG", 50, "X102") { Year = 2025, Number = "T21" };
            car3.GetInformation();
        }

        public static void Deneme() { }
    }
}
