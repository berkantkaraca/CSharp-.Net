namespace _23_Inheritance
{
    public class Phone
    {
        private string _brand;
        protected string _connectionType = "Kablolu Bağlantı"; //protected kullandık. bu sınıfta seti kapalı. sub classlarda kullanmak için 

        public Phone()
        {
            Console.WriteLine("Phone parametresiz");
        }
        public Phone(string brand)
        {
            Brand = brand;
        }

        public string ConnectionType
        {
            get { return _connectionType; }
        }
        public string Brand
        {
            get { return _brand; }
            private set { _brand = value; }
        }

        //Polimorfizim: Çok biçimlilik. Üst sınıftaki metodun davranışı değişti. base classtaki fonksiyona virtual keywordü eklendi. Kalıtım alan sınınf bu metodu override ederek değiştirebilir
        public virtual string Call()
        {
            return "Phone arama metodu çalıştı";
        }

        //Info metotları ToStirng ile yazılır.
        public string GetInfo()
        {
            return $"Marka: {Brand}, Bağlantı: {ConnectionType}";
        }

        public override string ToString()
        {
            return $"Marka: {Brand}, Bağlantı: {ConnectionType}";
        }
    }
}
