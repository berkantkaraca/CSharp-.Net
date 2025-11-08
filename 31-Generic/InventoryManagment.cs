namespace _31_Generic
{
    //Interface'de where T: Product eklediğimiz için burada da eklememiz lazım
    public class InventoryManagment<T> : IInventoryManagment<T> where T : Product
    {
        private List<T> products = new List<T>();

        public void Add(T item)
        {
            products.Add(item);
            Console.WriteLine($"{item.Name} added to inventory");
        }

        public void Decrease(T item, int amount)
        {
            item.DecreaseQuantity(amount);
        }

        public List<T> GetAll()
        {
            return products;
        }

        public void Inccrease(T item, int amount)
        {
            item.IncreaseQuantity(amount);
        }

        public void Remove(T item)
        {
            products.Remove(item);
            Console.WriteLine($"{item.Name} removed from inventory");
        }
    }
}
