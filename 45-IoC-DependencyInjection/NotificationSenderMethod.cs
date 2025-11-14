namespace _45_IoC_DependencyInjection
{
    public class NotificationSenderMethod
    {

        //Sadece o metotta kullanılacsa kullanılır.
        //CRUD işlemlerini EF ile yaptın. Get işlemini Adonet ile yapacaksan bu şekilde kullanabilirsin
        public void Notify(string message, IMessageService _messageService)
        {
            _messageService.SendMessage(message);
        }
    }
}
