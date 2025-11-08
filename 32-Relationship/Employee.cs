namespace _32_Relationship
{
    public class Employee
    {
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }
        public decimal Salary{ get; set; }

        public override string ToString()
        {
            return $"{Name} {Salary}"; 
        }
    }

    public class Developer : Employee
    {
        List<string> ProgrammingLanguage { get; set; }
        public Developer(string name, decimal salary, List<string> programmingLanguage) : base(name, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n {string.Join(", ", ProgrammingLanguage)}";
        }
    }

    public class Manager : Employee
    {
        List<Employee> Team { get; set; }

        public Manager(string name, decimal salary) : base(name, salary)
        {
            Team = new List<Employee>();
        }

        public  void AddToTeam(Employee employee)
        {
            Team.Add(employee);
        }

        public override string ToString()
        {
            string member = "";
            foreach (Employee employee in Team)
            {
                member += employee.Name + " ";
            }

            return base.ToString() + $"\n {member}";
        }
    }
}
