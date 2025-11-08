namespace _28_Interface
{
    public class Kaleci : IFutbolcu, IKaleci
    {
        public string Name { get; set; }
        public int Numara { get; set; }
        public int PasGucu { get; set; }
        public int SutGucu { get; set; }
        public int KosuGucu { get; set; }

        public void Kos()
        {
            Console.WriteLine("Kosu basladı...");
        }

        public void PasAt()
        {
            Console.WriteLine("Pas atılıyor...");
        }

        public void SutCek()
        {
            Console.WriteLine("Sut cekiliyor...");
        }

        public void TopKurtar()
        {
            Console.WriteLine("Top kurtarılıyor...");
        }
    }
}
