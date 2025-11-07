namespace _22_Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Enum: numaralı liste mantığındadır

            Order order1 = new Order();
            order1.Name = "A";
            order1.OrderId = 1;
            order1.Status = OrderStatus.Delivered;
            order1.Detail();

            //cast edilebilir
            Console.WriteLine((int)OrderStatus.Cancelled);
            Console.WriteLine((OrderStatus)102);

            Schedule schedule = new Schedule();
            schedule.WorkDays = WorkDays.Monday; //birden fazla atama işlemi
            schedule.PrintSchedule();
        }
    }
}