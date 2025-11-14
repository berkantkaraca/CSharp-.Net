namespace _45_IoC_DependencyInjection
{
    public class NotificationSenderConstructor
    {

        // Constructor Injection
        //2 yapı var şuan. hangisini new yapacak? Bu yüzden dışardan alınmalı. Bu yüzden d.injection yaptık. Soyut arayüzü kullanıyoruz. Alt sınıf ne olursa olsun hepsi için çalışacak
        private readonly IMessageService _messageService;

        public NotificationSenderConstructor(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify(string message)
        {
            _messageService.SendMessage(message);
        }
    }
}
