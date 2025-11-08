namespace _31_Generic
{
    public interface IInventoryManagment<T> where T : Product 
    {
        void Add(T item);
        void Remove(T item);
        List<T> GetAll();
        void Decrease(T item, int amount);
        void Inccrease(T item, int amount);
    }
}
