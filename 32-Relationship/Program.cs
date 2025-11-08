namespace _32_Relationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Has-A
            //Sahiplik İlişkileri bir nesnenin diğer bir nesneye sahip olduğu durumu ifade eder
            //1-1, 1-N, N-N ilişkileri has a ilişkileridir çoka1
            //Yazar-Kitap ilişkisi örnek
            Library library = new Library("Kütüphane")
            {
                Books = new List<Book>
                {
                    new Book("K1", new Author("Y1","TR")),
                    new Book("K2", new Author("Y2","TR")),
                    new Book("K3", new Author("Y3","TR")),
                }
            };

            Console.WriteLine(library);
            #endregion

            #region Is-A
            //Bir türdür. nesneler arasındaki hiyerarşik bir ilişki kurar. kalıtımdır
            Developer dev1 = new Developer("A", 1, new List<string> { "a", "b"});
            Developer dev2 = new Developer("B", 2, new List<string> { "c", "d"});
            Developer dev3 = new Developer("C", 3, new List<string> { "e", "f"});

            Manager manager = new Manager("d", 12);
            manager.AddToTeam(dev1);
            manager.AddToTeam(dev2);

            Console.WriteLine(manager);
            #endregion

            #region Use-A
            //Kullanır, bir nesneyi başka bir nesneyi kullanarak geçici bir ilişki kurduğu durum
            Customer customer = new Customer("a", "b");
            Order order = new Order(101, customer, 12);
            PaymentProcessor paymentProcessor = new PaymentProcessor("ss");

            order.ProcessPayment(paymentProcessor);
            #endregion

            #region Is-Part-Of
            //Parça bütün ilişkisi: bir nesnenin diğer nesenenin ayrılmaz bir parçası olduğunu ifade eder.
            Engine engine = new Engine("a", 32);
            MusicSystem musicSystem = new MusicSystem("a");

            Car car = new Car("a", engine);

            car.StartCar();

            //car.MusicSystem = musicSystem;
            //car.StartCar();
            #endregion
        }
    }
}
