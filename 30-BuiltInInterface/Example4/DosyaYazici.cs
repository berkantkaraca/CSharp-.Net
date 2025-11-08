namespace _30_BuiltInInterface.Example4
{
    public class DosyaYazici : IDisposable
    {
        public StreamWriter _writer;

        public DosyaYazici(string dosyaYolu)
        {
            _writer = new StreamWriter(dosyaYolu);
        }

        public void Yaz(string mesaj)
        {
            if (_writer == null)
                throw new Exception("Hata");
            _writer.WriteLine(mesaj);
        }

        //iş bitince nesneyi siler
        //iş bittikten sonra dispose yapıp silinmeli
        public void Dispose()
        {
            _writer?.Dispose();
            _writer = null;
        }
    }
}
