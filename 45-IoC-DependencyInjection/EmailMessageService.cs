namespace _45_IoC_DependencyInjection
{
    public class EmailMessageService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Email: " + message);
        }
    }
}
