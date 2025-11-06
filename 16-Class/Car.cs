namespace _16_OOP_Class
{
    public class Car
    {
        //Fields: bir sınıfın örneğinde (instance) saklanacak veri veya durumu tanımlayan değişkenlerdir. (Nesneye ait)
        private string _brand = "Mercedes";
        private string _number;
        private string _model;
        private int _year;
        private double _fuel;

        //Properties: bir sının alanlarına (Field) dışarıdan (Güvenlikli) erişimi sağlamak için kullanılan yapılardır. 

        //Only Read
        //1. Yöntem Set bloğunun tamamen kaldırma
        //public string Brand { get { return _brand; } }

        //2. Yöntem Set bloğunu private yap.
        //public string Brand
        //{
        //    get
        //    {
        //        return _brand;
        //    }
        //    private set
        //    {
        //        _brand = value;
        //    }
        //}

        //3. Yöntem Expression Bodied Members
        public string Brand => _brand;

        //Only Write
        public string Number
        {
            private get { return _number; }
            set { _number = value; }
        }

        public string Model
        {
            get
            {
                return _model.ToUpper();
            }
            set
            {
                _model = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (value >= DateTime.Now.Year)
                    _year = value;
                else
                    _year = DateTime.Now.Year; //throw new Exception("")
            }
        }
        public double Fuel
        {
            get { return _fuel; }
            set
            {
                if (value >= 0 && value <= 80)
                    _fuel = value;
                else
                    throw new Exception("Eksik yada fazla yakıt!");
            }
        }

        //Constructor
        public Car()
        {

        }
        public Car(string brand, double fuel)
        {
            _brand = brand;
            Fuel = fuel;
        }
        public Car(string brand, double fuel, string model)
        {
            _brand = brand;
            Fuel = fuel;
            Model = model;
        }

        //Methods
        public void GetInformation()
        {
            Console.WriteLine($"Arabanın Markası: {_brand} Modeli: {_model} Number: {_number} Yılı: {_year} Yakıtı: {_fuel}");
        }
    }
}
