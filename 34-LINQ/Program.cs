namespace _34_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINGQ - Language Integrated Query: C#'da veri sorgulama ve manipülasyonu için kullanılan bir özelliktir.
            List<Student> students = new List<Student>()
            {
                new Student {Id = 1, Name ="Ahmet", Age = 20, City = "İstanbul" , DepartmentId = 101},
                new Student {Id = 2, Name ="b", Age = 22, City = "Ankara",DepartmentId = 102},
                new Student {Id = 3, Name ="c", Age = 21, City = "İzmir", DepartmentId = 102},
                new Student {Id = 4, Name ="d", Age = 19, City = "İstanbul", DepartmentId = 102},
            };

            List<Department> departments = new List<Department>()
            {
                new Department {Id = 101, Name = "PC" },
                new Department {Id = 102, Name = "Elek" },
                new Department {Id = 103, Name = "Mak" },
            };

            //Bellekte sorgu haline getirip sqle istek atar. Hazırlanan sorgu iterasyon işlemi başladığında veritabanına istek atar ve sonucu getirir. 
            var filter = students.Where(x => x.Age > 20).Where(x => x.City == "İstanbul"); //sorgu burda oluşur. veya bu sorgunun sonuna ToList yazdığı zaman orda da bir iterasyon yaptığı için o an sorgulama gerçekleştirilir. Bunlardan önce sorgulama gerçekleşmez. Bu liste döndüren türlerde olur. Sum, First vs gibi türlerde sorgulama hemen gerçekleşir
            foreach (var item in filter) { } //veritabanına bu anda istek atılır

            #region Where
            bool whereDeneme(Student student) => student.Age > 20;

            ////Method Syntax
            var filteredStudents = students.Where(x => x.Age > 20 && x.City == "İstanbul").ToList(); //Where içine whereDeneme yazsan da olur. Tolist demezsek IEnumarble dönüyo. Liste ile çalıştığı için ekledi

            students.Where(x => x.Age > 20).Where(x => x.City == "İstanbul"); //Chain metot mantığı: ardarda where yazımı

            foreach (var item in filteredStudents)
            {
                Console.WriteLine(item);
            }

            //Query Syntax
            var filteredStudents2 = from s in students
                                    where s.Age > 20 && s.City == "İstanbul"
                                    select s;
            #endregion

            #region OrderBy
            var sortedList = students.OrderBy(x => x.Age).ToList();
            sortedList = students.OrderBy(x => x.Age).ThenBy(x => x.City).ToList(); //ilk yaşı sıralar. eğer yaşlar aynı ise şehir ismine göre sırala
            //descending için OrderByDescending ve ThenByDescending kullanılır. Default olarak ascending dir

            var sortedList2 = from s in students
                              orderby s.Age, s.City ascending // descending
                              select s;
            #endregion

            #region GroupBy
            var groupedStudents = students.GroupBy(x => x.City).ToList();

            foreach (var item in groupedStudents)
            {
                //IGrouping türünden gelir. O yüzden key ile gruplama kriterine erişilir. item.Key değerinde gelir. Bir foreach ile içindeki öğrencilere erişilir
                Console.WriteLine(item.Key);
                //item.Sum();
                item.Count();

                foreach (var student in item)
                {
                    Console.WriteLine(student);
                }
            }

            var groupedStudents2 = from s in students
                                   group s by s.City;
            #endregion

            #region Select
            //StudentDto türünden bir liste döner
            var studentSelect = students.Select(x => new StudentDTO
            {
                Adi = x.Name,
                Sehir = x.City
            }).ToList();

            //Where selecten önce yapılsaydı student üzerinden yapar. ama son aşamada yapılırsa StudentDTO türünden koşul uygular
            var studentSelect1 = students.Where(x => x.Age > 0).Select(x => new StudentDTO
            {
                Adi = x.Name,
                Sehir = x.City
            }).Where(x => x.Adi != "").ToList();

            foreach (var item in studentSelect)
            {
                Console.WriteLine(item.Sehir + " " + item.Adi);
            }

            //new'den sonra bir şey yazmadığında anonim bir class oluşur.
            var studentSelect2 = students.Select(x => new
            {
                Name1 = x.Name,
                City1 = x.City
            }).ToList();

            //Anonim class oluşturur
            var deneme = new { Adi = "sa" };
            //deneme.Adi = "1"; // sonradan atama yapılamaz

            var deneme2 = new StudentDTO { Adi = "sa", Sehir = "sdas" };
            deneme2.Sehir = "sdgf"; //set tanımlandı değişim yapılabilir
            //deneme2.Adi = "lskjfdkl"; //init tanımlandığı için hata verir

            var deneme3 = new StudentDTO { Adi = "sa", Sehir = "sdas" };

            //record olduğu için eşit çıkar. value type gibi çalışır
            if (deneme2 == deneme3)
                Console.WriteLine("eşit");
            else
                Console.WriteLine("eşit değil");


            var studentSelect3 = from s in students
                                 select new
                                 {
                                     Adi = s.Name,
                                 };
            #endregion

            #region join
            //ilk parametre: bağlanılacak liste
            //ikinci parametre: ilk listedeki bağlanılacak kolon
            //üçüncü parametre: ikinci listedeki bağlanılacak kolon
            //dördüncü parametre: yeni oluşacak nesne
            var joinedData = students.Join(departments,
                                        s => s.DepartmentId,
                                        d => d.Id,
                                        (s, d) => new
                                        {
                                            //student = s,
                                            //DepartmentName = d

                                            Adi = s.Name,
                                            Yasi = s.Age,
                                            Bolum = d.Name
                                        }).ToList();
            //Oluşan yapı bu
            //public class JoinedResult
            //{
            //    public Student student { get; set; }
            //    public Department department { get; set; }
            //}

            //query syntax
            var joinedData2 = from s in students
                              join d in departments
                              on s.DepartmentId equals d.Id
                              select new
                              {
                                  s,
                                  d
                              };
            #endregion

            #region All
            //where gibi ama tüm koşulların sağlanıp sağlanmadığını kontrol eder
            bool allStudentPassed = students.All(x => x.Age > 18); //tüm yaşlar 18 den büyükse true değilse false
            #endregion

            #region Any
            //where gibi ama en az bir koşulun sağlanıp sağlanmadığını kontrol eder
            bool anyStudentPassed = students.Any(x => x.Age > 18); // en az bir yaş 18 den büyükse true değilse false
            #endregion

            #region Average
            double averageAge = students.Average(x => x.Age);
            #endregion

            #region Count
            var studentCount = students.Count(); //tüm öğrenci sayısı
            var istanbulStudentCount = students.Count(x => x.City == "İstanbul"); //istanbul öğrenci sayısı
            #endregion

            #region Max-Min
            var maxAge = students.Max(x => x.Age);
            var minAge = students.Min(x => x.Age);
            #endregion

            #region Sum
            var totalAge = students.Sum(x => x.Age);

            //Count ile aynı işi yapar
            var numOfAdults = students.Sum(x =>
            {
                if (x.Age >= 18)
                    return 1;
                else
                    return 0;
            });
            #endregion

            #region Element-ElementOrDefault
            //indexof mantığında çalışır. Koleksiyon içindeki belirli bir konumdaki öğeyi almak için kullanılır
            //Element belirtilen konumda değer yoksa exception fırlatır (try-catch ile yakala). ElementOrDefault ise default değer döner. class ise null gibi
            Student studentIndex = students.ElementAt(2); //3213241 arat hata fırlatılır
            Console.WriteLine(studentIndex);

            Student? studentAtIndex = students.ElementAtOrDefault(2); //3213241 arat null döner
            if (studentAtIndex != null)
                Console.WriteLine(studentAtIndex);
            else
                Console.WriteLine("Bulunamadı");
            #endregion

            #region First-FirstOrDefault
            //Bu tam olarak indexof gibi çalışır. Burda koşul ayarlayabiliriz. Koşulu sağlayan ilk bulduğu nesneyi döner. First hata fırlatır, diğeri null döner
            Student firstStudent = students.First(x => x.Age > 19); //içi boş bırakılrsa ilk öğeyi döner
            //19dan büyük 2 kişi var. burda ilk bulduğunu döner sadece
            Console.WriteLine(firstStudent);

            Student firstOrStudent = students.FirstOrDefault(firstStudent => firstStudent.Age > 20);
            if (firstOrStudent != null)
                Console.WriteLine(firstOrStudent);
            else
                Console.WriteLine("Bulunamadı");
            #endregion

            #region Last-LastOrDefault
            //Last da First gibi çalışır. Sondan başlar aramaya
            Student lastStudent = students.Last(x => x.Age > 19);
            Console.WriteLine(lastStudent);

            Student lastOrStudent = students.LastOrDefault(lastStudent => lastStudent.Age > 20);
            if (lastOrStudent != null)
                Console.WriteLine(lastOrStudent);
            else
                Console.WriteLine("Bulunamadı");
            #endregion

            #region Single-SingleOrDefault
            //Bir koleksiyon içindeki belirli bir koşulu sağlayan tek öğeyi döner. Bulamazsa hata fırlatır. Eğer koleksiyonda bu koşulu sağlayan birden fazla öğe varsa hata fırlatır.
             Student singleStudent = students.Single(x => x.Name == "Mehmet"); //Id tek olduğu için hata fırlatmaz
             Console.WriteLine(singleStudent);

            Student singleStudent2 = students.Single(x => x.Age > 30); //birden fazla kayıt olduğu için hata fırlatır

            //SingleOrDefault'da eğer koşulu sağlayan birden fazla öğe varsa hata fırlatır. Ancak hiç öğe yoksa null döner
            Student singleOrStudent = students.SingleOrDefault(x => x.Id == 5); //Id 5 olmadığı için null döner
            if (singleOrStudent != null)
                Console.WriteLine(singleOrStudent);
            else
                Console.WriteLine("Bulunamadı");
            #endregion

            #region Skip-SkipWhile
            //adet ve koşul bazlı atlama yaparlar
            //belirli bir satıda öğeyi veya bir koşulu atlamak için kullanılır
            var afterSkip = students.Skip(2).ToList(); //ilk ikisini atladı

            var afterWhileSkip = students.OrderBy(x => x.Age).SkipWhile(x => x.Age < 21).ToList(); // ilk bulduğu 21den küçük olanları atlar

            Console.WriteLine("Skip");
            foreach (var item in afterSkip)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Take-TakeWhile
            Console.WriteLine("Take");
            var firstThreeStudents = students.Take(3).ToList(); // ilk 3ü listeler
            var firstThreeStudents2 = students.TakeWhile(x => x.Age < 21).ToList(); // 21den küçük olanları alır ilk bulduğu 21den büyük olana kadar

            foreach (var item in firstThreeStudents)
            {
                Console.WriteLine(item);
            }
            #endregion

            Console.WriteLine("Dinamik Where Koşulu");
            GetDataWheredIEnumerable(students, s => s.Age > 20);

            //query syntaxta değişken tanımlama
            var numbers2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var query = from num in numbers2
                        let squared = num * num //let ile sorgu içinde değişken tanımlanır
                        where squared > 25
                        select new { originalNum = num, squaredNum = squared };
            foreach (var item in query)
            {
                Console.WriteLine($"Original: {item.originalNum}, Squared: {item.squaredNum}");
            }
        }

        //Dinamik Expression bir where koşulu alır.
        public static void GetDataWheredIEnumerable(IEnumerable<Student> source, Func<Student, bool> whereExp = null)
        {
            if (whereExp != null)
                source = source.Where(whereExp);

            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }
    }
}
