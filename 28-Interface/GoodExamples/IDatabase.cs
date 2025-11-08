namespace _28_Interface.GoodExamples
{
    public interface IDatabase
    {
        // bu şekilde tüm iş akışı belli. databse türü değişsede sadece kalıtımla ilgili yerde implementeni yap
        void Create(string name, decimal price, int stock);
        void Delete(int id);
    }
}