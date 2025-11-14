namespace _45_IoC_DependencyInjection
{
    public class NotificationSenderProperty
    {
        public IMessageService _messageService { get; set; }
        public void Notify(string message)
        {
            _messageService.SendMessage(message);
        }
    }
}
