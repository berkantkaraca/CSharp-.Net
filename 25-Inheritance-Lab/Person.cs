namespace _25_Inheritance_Lab
{
    public class Person
    {
        private static int _studentCounter = 100;
        private static int _teacherCounter = 300;
        private static int _adminCounter = 600;

        protected Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Id = GetNextId(this);
        }

        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        protected static int GetNextId(Person person)
        {
            return person switch
            {
                Student => _studentCounter++,
                Teacher => _teacherCounter++,
                Administrator => _adminCounter++,
                _ => 0
            };
        }

        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName} ({Email})";
        }
    }
}
