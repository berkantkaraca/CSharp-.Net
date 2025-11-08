namespace _25_Inheritance_Lab
{
    public class Administrator : Person
    {
        public string Role { get; set; }
        public List<Person> ManagedPeople { get; private set; } = new();
        public Administrator(string firstName, string lastName, string email, string role) : base(firstName, lastName, email)
        {
            Role = role;
        }

        public void AddPerson(Person p)
        {
            if (p is not Student)
                ManagedPeople.Add(p);
            else
                throw new Exception("Öğrenci yönetilemez!");
        }

        public override string ToString()
        {
            return base.ToString() + $" | Role {Role}, Persons: {ManagedPeople.Count}";
        }
    }
}
