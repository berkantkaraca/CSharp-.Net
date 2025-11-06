namespace _17_Class_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(101, "Fatih", "Alkan") { Department = "BİL. Müh." };

            student1.AddExamScore(80);
            student1.AddExamScore(75);
            student1.AddExamScore(90);

            Console.WriteLine(student1.DisplayInfo());

            Product product1 = new Product("Çikolata", 100);
            Product product2 = new Product("Çikolata", 100);

            if (product1 == product2) 
                Console.WriteLine("Aynı");
            else
                Console.WriteLine("Değil"); //çıktı değil olur. referans tip olduğu için eşitlik kontrolü referanslara göre yapılır

            product1.Equals(product2); // Equals değerlerin eşitliğini kontrol eder. 

            var p1 = new Product("Dizüstü PC", 5000);
            var p2 = new Product("Masaüstü PC", 5000, "Elektronik");
            var p3 = new Product("Klavye", 4500, "Elektronik");
            var p4 = new Product("PC", 4500);

            var order = new Order(101);
            order.AddProduct(p1);
            order.AddProduct(p2);

            Console.WriteLine(order.DisplayOrderSummary());

            //Siparişin toplam fiyatını para formatına döndür
            Console.WriteLine("Toplam fiyat: " + order.CalculateTotalPrice().ToString("C2"));

            //Sipariş listesindeki en pahalı ürünü bulun
            Console.WriteLine("En pahalı ürün: " + order.GetMaxPrice());

            //belirli bir oranda indirim uygulayan metot(%10)
            Console.WriteLine("İndirimli fiyat: " + order.ApplyDiscount(10));

            var order2 = new Order(102);
            order2.AddProduct(p1);
            order2.AddProduct(p2);
        }
    }
}
