using _34_AdoNet.Models;
using _34_AdoNet.Repo;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _34_AdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=KDK-302-YZ-PC21;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            #region DataReader
            SqlConnection conn1 = new SqlConnection(connectionString);
            //conn.ConnectionString = connectionString;
            conn1.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [TABLE]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn1;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["Id"] + ") " + dr["Name"] + " - " + dr["Age"]);
            }

            dr.Close();
            conn1.Close();
            #endregion

            #region DataAdapter
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlDataAdapter adaptor = new SqlDataAdapter("SELECT * FROM [TABLE]", connectionString);
            DataTable dt = new DataTable();
            adaptor.Fill(dt); // Adaptor ile gelen veri Datatable'a taşınır
            conn.Close();

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine(ds.Tables[0].Rows[i]["Name"] + " " + ds.Tables[0].Rows[i]["Age"]);
            }
            #endregion

            IStudentRepo repo = new StudentRepo();

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
