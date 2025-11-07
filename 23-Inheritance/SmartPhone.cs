namespace _23_Inheritance
{
    //Mülakat: .Nette 1 sınıf sadece 1 sınıftan kalıtım alır. Multi Inheritance yoktur.
    public sealed class SmartPhone : MobilePhone //sealed: Smartphonedan itibaren kalıtım olayı yapılamaz
    {
        public bool FrontCam { get; set; }
        public SmartPhone()
        {
            _connectionType = "5G";
        }

        public SmartPhone(string brand) : base(brand) 
        {
            _connectionType = "5G";
        }

        public string DoVideoCall()
        {
            if (FrontCam)
                return "Görüntülü arandı";
            else
                return "Ön kamera yok";
        }

        //metoduda sealed olarak işaretleyebilirsin. Sınıfa ait metotta kullanılmaz. polimorfizmi bitirmek istediğin metotta kullanılabilir
        public sealed override string Call()
        {
            return "Smart arama metodu çalıştı";
        }
        public override string ToString()
        {
            return $"Marka: {Brand}, Bağlantı: {ConnectionType}, Kamera: {HasCamera}, Dokunmatik: {IsTouched}, Ön Kamera: {FrontCam}";
        }

        //Metot Hiding: Üst sınıftaki metodu kullanmak yerin new yaparak bu sınıfa ait yeni bir metot oluşturulabilir.
        //public new string Call()
        //{
        //    return "";
        //}
    }
}
