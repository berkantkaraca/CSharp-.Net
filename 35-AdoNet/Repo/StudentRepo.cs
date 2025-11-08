using _34_AdoNet.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _34_AdoNet.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private string connectionString = "Data Source=KDK-302-YZ-PC21;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private SqlConnection conn;

        public StudentRepo()
        {
            conn = new SqlConnection(connectionString);
        }

        public void Add(Student student)
        {
            conn.Open();
            string query = $"INSERT INTO Student (Name, Age) VALUES (@Name, @Age)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Delete(int id)
        {
            conn.Open();
            string query = "DELETE FROM Student WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            conn.Open();
            string query = "SELECT * FROM Student";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Age = (int)reader["Age"],
                });
            }

            reader.Close();
            conn.Close();

            return students;
        }

        public Student? GetById(int id)
        {
            Student student = null;

            conn.Open();
            string query = "SELECT * FROM Student Where Id=@Id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                student = new Student()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Age = (int)reader["Age"],
                };
            }

            reader.Close();
            conn.Close();

            return student;
        }

        public void Update(Student student)
        {
            conn.Open();
            string query = "UPDATE Student SET Name=@Name, Age=@Age WHERE Id=@Id";
            
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = student.Id;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = student.Name;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = student.Age;
            cmd.ExecuteNonQuery();
            
            conn.Close();
        }
    }
}
