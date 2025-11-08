namespace _25_Inheritance_Lab
{
    public class Student : Person
    {
        public IList<int> Grades { get; private set; } = new List<int>();
        public string Number { get; set; } = new Guid().ToString().Substring(1, 4);
        public Student(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
        }

        public void AddGrade(int score)
        {
            if (score >= 0 && score <= 100)
                Grades.Add(score);
            else
                throw new Exception("Öğrenci notu 0 ile 100 arasında olamalıdır!");
        }

        public double CalculateAverage()
        { 
            return Grades.Count() == 0 ? 0 : Grades.Average();
        }

        public override string ToString()
        {
            return base.ToString() + " | Ortalama: " + CalculateAverage();
        }
    }
}
