using _40_EntityFramework_Inheritance.Contexts;
using _40_EntityFramework_Inheritance.Models;

namespace _40_EntityFramework_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EF, inheritance yapısını algılar ve kendi kod yapısına uygun tabloları veri tabanına contect algoritmasına göre gönderir

            Console.WriteLine("TPH");
            TPHAppDbContext tphAppDbContext = new TPHAppDbContext();

            tphAppDbContext.Managers.Add(new Manager() { Name = "Ahmet", Bonus = 11 });
            tphAppDbContext.Developers.Add(new Developer() { Name = "Mehmet", ProgLanguage = "C#" });
            tphAppDbContext.SaveChanges();

            Console.WriteLine("Manager");
            var result1 = tphAppDbContext.Managers.ToList();
            foreach (var item in result1)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} Bonus: {item.Bonus}");
            }

            Console.WriteLine("Developer");
            var result2 = tphAppDbContext.Developers.ToList();
            foreach (var item in result2)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} PL: {item.ProgLanguage}");
            }

            Console.WriteLine("Employee");
            var result3 = tphAppDbContext.Employees.ToList();
            foreach (var item in result3)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name}"); //Sadece emoployeede olan veriler yazılır. Bonus yazdıramazsın. cast etmen lazım

                if (item is Developer)
                {
                    var dev = (Developer)item;
                    Console.WriteLine($"Id: {dev.Id} Name: {dev.Name} PL: {dev.ProgLanguage}");
                }
                else
                {
                    var man = (Manager)item;
                    Console.WriteLine($"Id: {man.Id} Name: {man.Name} Bonus: {man.Bonus}");

                }
            }

            /******************************************************************************/

            Console.WriteLine("TPT");
            TPTAppDbContext tptAppDbContext = new TPTAppDbContext();

            tptAppDbContext.Managers.Add(new Manager() { Name = "Ahmet", Bonus = 11 });
            tptAppDbContext.Developers.Add(new Developer() { Name = "Mehmet", ProgLanguage = "C#" });

            //Employee abstract olmasaydı eklerdik. Bu şekilde developer veya manager olmayan employee ekledi
            //tptAppDbContext.Employees.Add(new Employee() { Name = "Ayşe" });

            tptAppDbContext.SaveChanges();

            Console.WriteLine("Manager");
            var result4 = tptAppDbContext.Managers.ToList();
            foreach (var item in result4)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} Bonus: {item.Bonus}");
            }

            Console.WriteLine("Developer");
            var result5 = tptAppDbContext.Developers.ToList();
            foreach (var item in result5)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} PL: {item.ProgLanguage}");
            }

            Console.WriteLine("Employee");
            var result6 = tptAppDbContext.Employees.ToList();
            foreach (var item in result6)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name}"); //Sadece emoployeede olan veriler yazılır. Bonus yazdıramazsın. cast etmen lazım

                if (item is Developer)
                {
                    var dev = (Developer)item;
                    Console.WriteLine($"Id: {dev.Id} Name: {dev.Name} PL: {dev.ProgLanguage}");
                }
                else if (item is Manager)
                {
                    var man = (Manager)item;
                    Console.WriteLine($"Id: {man.Id} Name: {man.Name} Bonus: {man.Bonus}");
                }
                else
                {
                    Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
                }
            }
        }
    }
}
