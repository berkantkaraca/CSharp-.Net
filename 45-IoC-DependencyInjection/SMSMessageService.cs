namespace _45_IoC_DependencyInjection
{
    public class SMSMessageService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("SMS: " + message);
        }
    }
}
