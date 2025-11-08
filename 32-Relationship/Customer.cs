namespace _32_Relationship
{
    public class Customer
    {
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Name} {Email}";
        }
    }

    public class Order
    {
        public Order(int orderId, Customer customer, decimal totalAmount)
        {
            OrderId = orderId;
            Customer = customer;
            TotalAmount = totalAmount;
        }

        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }

        //Bu fonksiyonda PaymentProcessor kullandığı için use a ilişkisi var
        public void ProcessPayment(PaymentProcessor paymentProcessor)
        {
            Console.WriteLine($"{OrderId}");
            paymentProcessor.ProcessPayment(this);
        }

        public override string ToString()
        {
            return $"{OrderId} {Customer} {TotalAmount}";
        }
    }

    public class PaymentProcessor
    {
        public string ProviderName { get; set; }

        public PaymentProcessor(string providerName)
        {
            ProviderName = providerName;
        }

        //Bu fonksiyonda orderı kullandığı için use a ilişkisi var
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"{ProviderName} {order}");
        }
    }
}
