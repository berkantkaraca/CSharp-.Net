using _34_AdoNet.Models;

namespace _34_AdoNet.Repo
{
    public interface IStudentRepo
    {
        void Add(Student student); 
        void Update(Student student); 
        void Delete(int id);
        List<Student> GetAll();
        Student? GetById(int id);
    }
}
