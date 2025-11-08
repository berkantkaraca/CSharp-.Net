namespace _31_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Generic: türe bağlı kalmadan kod yazılması. List int de çalışır string de gibi
            List<int> list = new List<int>();

            //where T: class eklediğinde bu hata verir.
            //Box<int> intBox = new Box<int>();
            //intBox.AddItem(1);
            //Console.WriteLine(intBox.GetItem());

            Box<string> strBox = new Box<string>();
            strBox.AddItem("1");
            Console.WriteLine(strBox.GetItem());

            Box<Person> personBox = new Box<Person>();
            personBox.AddItem(new Person());

            Deneme<int, string> deneme = new Deneme<int, string>();

            ElectronicProduct laptop = new ElectronicProduct("laptop", 50000, 100, 2);
            ElectronicProduct phone = new ElectronicProduct("laptop", 150000, 150, 2);

            FoodProduct apple = new FoodProduct("Apple", 50, 100);
            FoodProduct bread = new FoodProduct("Bread", 150, 1000);

            IInventoryManagment<ElectronicProduct> electronics = new InventoryManagment<ElectronicProduct>();
            electronics.Add(laptop);
            electronics.Add(phone);

            foreach (var item in electronics.GetAll())
            {
                Console.WriteLine(item);
            }

            electronics.Decrease(laptop, 50);
            electronics.Inccrease(phone, 8);

            IInventoryManagment<FoodProduct> foods = new InventoryManagment<FoodProduct>();
            foods.Add(apple);
            foods.Add(bread);

            foreach (var item in foods.GetAll())
            {
                Console.WriteLine(item);
            }

            foods.Decrease(apple, 50);

            //yeni bir ürün geldiğinde o class oluştur ve kullan
        }
    }

    //class -> T referans tip olmalı
    //struct -> T value tip olmalı. bu sefer string ve person kızardı
    //new() -> Boş bir constructor a sahip olmalıdır.
    //Person -> sadece Person class'ı ve ondan türemiş sınıfları ister. 
    //IMyInterface -> sınıftaki gibi. bu interface den implemente edilmiş olmalı
    public class Box<T> where T : class
    {
        private T item;

        public void AddItem(T value)
        {
            item = value;
        }

        public T GetItem() { return item; }
    }

    //birden fazla parametre alan genericde olabilir
    public class Deneme<Tkey, Tvalue>
    {

    }

    public interface IRepository<T>
    {
        void Add(T value);
        void Update(T value);
    }

    public class KitapRepository : IRepository<Kitap>
    {
        public void Add(Kitap value)
        {
            throw new NotImplementedException();
        }

        public void Update(Kitap value)
        {
            throw new NotImplementedException();
        }
    }

    public class Kitap
    {

    }

    public class Person
    {

    }

    public class Developer : Person { }
    public class HR : Person { }
    public class Book : Person { }
}
