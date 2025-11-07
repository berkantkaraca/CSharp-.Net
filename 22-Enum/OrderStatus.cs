namespace _22_Enum
{
    public enum OrderStatus
    {
        /// <summary>
        /// özet yazılabilir
        /// </summary>
       // Pending, Processing, Shipped, Delivered, Cancelled
        Pending = 101, Processing, Shipped = 200, Delivered, Cancelled
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public OrderStatus Status { get; set; }

        public void Detail()
        {
            Console.WriteLine($"Id: {OrderId}, Name: {Name}, Status: {Status}");
        }
    }
}
