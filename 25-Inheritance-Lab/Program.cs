namespace _25_Inheritance_Lab
{
    internal class Program
    {
        static List<Person> persons = new List<Person>()
        {
            new Student("firstName", "lastName", "email"),
            new Student("firstName2", "lastName", "email"),
            new Teacher("firstName", "lastName", "email", "fen", 1),
            new Administrator("firstName", "lastName", "email", "Müdür"),
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Öğrenci Otomasyon Sistemi");
            while (true)
            {
                Console.WriteLine("Yönetim Sistemi");
                Console.WriteLine("1- Kişi Ekle");
                Console.WriteLine("2- Listeleme");
                Console.WriteLine("3- Cikis");
                Console.Write("Seçim: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Adı: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Soyadı: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Console.WriteLine("Tip: A: Ogrenci, B: Ogretmen, C: Yonetici");
                        Console.Write("Seçim: ");
                        string personType = Console.ReadLine();

                        if (personType == "A")
                        {
                            Console.Write("Ogrenci No: ");
                            int studentNo = int.Parse(Console.ReadLine());

                            persons.Add(new Student(firstName, lastName, email));
                        }
                        else if (personType == "B")
                        {
                            Console.Write("Brans: ");
                            string branch = Console.ReadLine();

                            Console.Write("Deneyim: ");
                            int experienceYear = int.Parse(Console.ReadLine());

                            persons.Add(new Teacher(firstName, lastName, email, branch, experienceYear));
                        }
                        else if (personType == "C")
                        {

                        }
                        else
                            Console.WriteLine("Gecersiz islem");
                        break;

                    case "2":
                        foreach (var item in persons)
                        {
                            if (item is Student)
                            {
                                var result = item as Student;
                                Console.WriteLine(result);
                            }
                            else if (item is Teacher)
                            {
                                var result = item as Teacher;
                                Console.WriteLine(result);
                            }
                            else
                            {
                                var result = item as Administrator;
                                Console.WriteLine(result);
                            }
                        }
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Gcersi");
                        break;
                }
            }
        }
    }
}