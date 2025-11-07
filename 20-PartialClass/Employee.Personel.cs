namespace _20_PartialClass
{
    public partial class Employee
    {
        public string  Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        partial void OnNameChanged(); //partial metot bildirimi
    }
}
