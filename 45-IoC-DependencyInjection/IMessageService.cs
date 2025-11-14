namespace _45_IoC_DependencyInjection
{
    //Dependency Inversion => IMessageService, EmailMessageService, SMSMessageService uygulaması
    public interface IMessageService
    {
        void SendMessage(string message);
    }
}
