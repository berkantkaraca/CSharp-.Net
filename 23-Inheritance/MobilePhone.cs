namespace _23_Inheritance
{
    public class MobilePhone : Phone
    {
        public bool HasCamera { get; set; }
        public bool IsTouched { get; set; }

        //private string _connectionType; aynı adda burdada değişken olsaydı üst kılastakine base._connectionType, bu sııftakine de this._connection ile erişilir

        //Phonedaki parametresize gider
        public MobilePhone() : base() //bu base() isteğe bağlıdır. base() yazmasakta parametresize gider
        {
            _connectionType = "3G";
            Console.WriteLine("Mobile Phone parametresiz");
        }

        //this ait olduğu nesneyi, base üst sınıfı simgeler
        //Phonedaki parametreliye gider
        public MobilePhone(string brand) : base(brand)
        {
            _connectionType = "3G";
        }

        public string TakePhoto()
        {
            if (HasCamera)
                return "Foto çekebilir";
            else
                return "Foto çekemez";
        }

        public override string Call()
        {
            return "Mobil arama metodu çalıştı";
        }

        public override string ToString()
        {
            return $"Marka: {Brand}, Bağlantı: {ConnectionType}, Kamera: {HasCamera}, Dokunmatik: {IsTouched}";
        }
    }
}
