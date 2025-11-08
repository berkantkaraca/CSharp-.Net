using _34_AdoNet.Models;

namespace _34_AdoNet.Repo
{
    public class StudentEntityRepo : IStudentRepo
    {
        StudentDBContext _context;

        public StudentEntityRepo()
        {
            _context = new StudentDBContext();
        }

        public void Add(Student student)
        {
            _context.Students.Add(student); //işlem bellekte cachedilir
            _context.SaveChanges(); //işlemi db ye yazar. int döner. kaç satırın etkilendiğini gösterir
        }

        public void Delete(int id)
        {
            //var student = _context.Students.Find(id); //önce belleğe bakar, yoksa db den getirir varsa bellekten çeker
            var student = _context.Students.FirstOrDefault(s => s.Id == id); //her seferinde db den çeker. bu yüzden find daha performanslıdır

            _context.Students.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student? GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
