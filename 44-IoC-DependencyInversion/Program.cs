namespace _44_IoC_DependencyInversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Soyutlara manuel bağlı kalmaktır.
            //Sınıflar doğrudan birbirine değil, Soyutlamalara (interface’e) bağımlı olurlar.
            //35-AdoNet örneğindeki StudentRepoyu daha sonra StudentEntityRepoya taşıdık. Bunun kolaylıkla geçiş yapmasını sağlayan Dependency Inversion kavramıdır. Soyut sınıflara bağlı olduğumuz için kolaylaştı. IStudent repo = new StudentRepo();

            //Loose Coupling olur
        }
    }
}
