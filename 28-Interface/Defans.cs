namespace _28_Interface
{
    public class Defans : IFutbolcu
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

        //Defans top kurtaramaz. kalecinin özelliğidir. Interface iyi tasarlanmamıştır. Solidin I prensibine aykırı. Eğer interface ayırma işlemi yapmayacaksan bunu aşağıdaki şekilde bırakacaksın.
        //IKaleciye aldığımız için burdan kaldırıyoruz.

        //public void TopKurtar()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
