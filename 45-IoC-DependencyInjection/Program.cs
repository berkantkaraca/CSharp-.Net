namespace _45_IoC_DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Constructor Injection
            //Milyonlarca nesne oluşturmayı engeller
            //Bağımlılığı azaltır
            //Güvenlik sağlar. DbContext sağlanmazsa çalışmamalı

            //Birden fazla NotificationSender nesnesi aynı IMessageService implementasyonunu kullanır
            IMessageService messageService = new SMSMessageService();
            messageService = new EmailMessageService(); //Türe göre değiştirmek kolaylaşır.

            NotificationSenderConstructor sender1 = new NotificationSenderConstructor(messageService);
            NotificationSenderConstructor sender2 = new NotificationSenderConstructor(messageService);
            NotificationSenderConstructor sender3 = new NotificationSenderConstructor(messageService);
            NotificationSenderConstructor sender4 = new NotificationSenderConstructor(messageService);

            sender1.Notify("Merhaba Dünya!");
            sender2.Notify("sa");
            sender3.Notify("naber");
            sender4.Notify("günaydın");
            #endregion

            #region Property Injection
            IMessageService messageService2 = new SMSMessageService();

            NotificationSenderProperty sender5 = new NotificationSenderProperty();
            sender5._messageService = messageService2; //Burada sonradan atama yapıldığı için unutulma riski var
            #endregion

            #region Method Injection
            IMessageService messageService3 = new SMSMessageService();

            NotificationSenderMethod sender6 = new NotificationSenderMethod();
            sender6.Notify("selma", messageService);
            sender6.Notify("selma", new EmailMessageService());
            #endregion
        }
    }
}
