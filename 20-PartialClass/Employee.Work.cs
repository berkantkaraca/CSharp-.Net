namespace _20_PartialClass
{
    public partial class Employee
    {
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public void DisplayWorkDetail()
        {
            Console.WriteLine($"Position: {Position}, Salary: {Salary}");
        }

        // NOT: partial metotlar iki aşamalıdır. 
        // Önce bir partial class içinde bildirimi (partial void OnNameChanged();), 
        // sonra diğer partial class içinde tanımı (partial void OnNameChanged() { ... }) yapılmalıdır. 
        // Eğer bildirimi yoksa "No defining declaration found..." hatası alınır.
        partial void OnNameChanged()
        {
            Console.WriteLine("İsim değiştirildi");
        }
    }
}
