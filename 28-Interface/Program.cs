//using _28_Interface.BadExamples;
using _28_Interface.GoodExamples;

namespace _28_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //yapılacak işlerin imzasını tutar
            //Gevşek bağalantı sağlar (loose coupling) 
            //mail gönderme operasyonunda sadece class ile yazıp hata alırsan sıkıntı. Interface ile sınırları çizmek lazım
            //Soyut kavramdır. içeride kod operasyonu yok. sadece yapılacaklar listesi vardır. 
            //Interface çoklu kalıtıma izin verir. Eğer impplemente ettikten sonra kullanamadığın bir metot vs çıkarsa o yanlış tasarımdır. Bunu parçalaman lazım.

            List<IFutbolcu> takim = new List<IFutbolcu>();

            takim.Add(new Defans { Name = "Apo"});
            takim.Add(new Defans { Name = "Sanchez" });
            takim.Add(new Forvet { Name = "Sanchez" });
            takim.Add(new Kaleci { Name = "Ugurcan" });

            //BadExamples
            SqlDatabase sqlDatabase = new SqlDatabase(); //sqldatabase'e bağlıyım. Interface olmadığı için farklı veritabanına geçişte sıkıntı yaşarım. MySql eklediğinde Create yerine Add yazılmış olabilir, yeni parametre ekleyebilir vb
            sqlDatabase.Create("Kalem", 250, 1000);

            //GoodExamples
            IDatabase database = new SqlDatabase();
            IDatabase database2 = new MySqlDatabase2(); //Burda fonksiyonları değiştirmek yerine sadece instance değiştirince iş çözülür. Bad example'ı yönetemezsin

            database.Create("Kalem", 250, 1000);
            database.Create("Kalem1", 250, 1000);
            database.Create("Kalem2", 250, 1000);
        }
    }
}
