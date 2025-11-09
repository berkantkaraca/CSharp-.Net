namespace _38_EntityFramework_CodeFirst_2.Models
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;

        public int Id { get; set; }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FullName => _firstName + " " + _lastName;
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
