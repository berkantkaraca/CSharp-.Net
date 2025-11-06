namespace _17_Class_Lab
{
    public class Student
    {
        //Field: dışarıdan doğrudan erişilemez (encapsulation)
        private int _id;
        private string _firstName;
        private string _lastName;
        private IList<int> _examScores; //ICollection tanımlamak daha kapsamlı olduğu için iyi

        //Constructor: nesne ilk oluşumunda çalışır
        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            _examScores = new List<int>(); //referans tip olduğu için newleme yapmalıyız aksi halde listeye ekleme yapıldığında null hatası verir
        }

        //id, ve name'in setine private yaptık. bunları constructordan alıcaz. dışarıdan işlem yapılamaz. içerde düzenlenmeli
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }

        public string FullName => _firstName + " " + _lastName;

        //Read-Write 
        //Güvenlik önlemi yapmayacaksan field tanımlamana gerek yok
        public string Department { get; set; }
        public double AvarageScore => _examScores.Count == 0 ? 0 : _examScores.Average();

        public void AddExamScore(int score)
        {
            if (score < 0 || score > 100)
                throw new ArgumentException("Not 0-100 arasında olmalı!");

            _examScores.Add(score);
        }

        //Sadece okuma yapan liste
        public IReadOnlyList<int> GetExamScores()
        {
            return _examScores.ToList().AsReadOnly(); //IList, ICollection olarak tanımlandığında AsReadOnly kullanılmaz bu yüzden ToList ile listeye çevirip readonly yapıyoruz
            //return _examScores.AsReadOnly(); // List tanımlandığında bu şekilde de yapılabilir
        }

        public string DisplayInfo()
        {
            return $"Id: {Id} Ad-Soyad: {FullName} Departman: {Department} \nOrtalama: {AvarageScore:F3} \nNotlar: {string.Join(", " , _examScores)}";
        }
    }
}
