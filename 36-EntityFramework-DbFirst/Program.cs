using _34_AdoNet.Models;
using _34_AdoNet.Repo;
using Microsoft.EntityFrameworkCore;

namespace _34_AdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PMC de bu kodu çalıştırman lazım
            //Scaffold-DbContext "Data Source=KDK-302-YZ-PC21;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer

            IStudentRepo repo = new StudentEntityRepo(); //Adonete göre sadece nesne oluşturma kısmını değiştirdik. İyi bir soyutlama oldu.

            while (true)
            {
                Console.WriteLine("1- Listele");
                Console.WriteLine("2- Ekle");
                Console.WriteLine("3- Sil");
                Console.WriteLine("4- Güncelle");
                Console.WriteLine("5- Cikis");

                Console.Write("Secim: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        foreach (var item in repo.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "2":
                        Console.Write("Adi: ");
                        string name = Console.ReadLine();

                        Console.Write("Yas: ");
                        int age = int.Parse(Console.ReadLine());

                        repo.Add(new Student
                        {
                            Name = name,
                            Age = age
                        });
                        break;

                    case "3":
                        Console.Write("Silinecek Id: ");
                        int deletedId = int.Parse(Console.ReadLine());
                        repo.Delete(deletedId);
                        break;

                    case "4":
                        Console.Write("Silinecek Id: ");
                        int updateId = int.Parse(Console.ReadLine());
                        var student = repo.GetById(updateId);

                        Console.WriteLine("Ogrenci: " + student);

                        Console.Write("Guncel Adi: ");
                        string updatedName = Console.ReadLine();

                        Console.Write("Guncel Yas: ");
                        int updatedAge = int.Parse(Console.ReadLine());

                        repo.Update(new Student
                        {
                            Id = updateId,
                            Name = updatedName,
                            Age = updatedAge
                        });

                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
