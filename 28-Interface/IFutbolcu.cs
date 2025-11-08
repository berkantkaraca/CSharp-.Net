namespace _28_Interface
{
    public interface IFutbolcu
    {
        //interface'in default access modifier'ı public. classta private
        string Name { get; set; }
        int Numara { get; set; }
        int PasGucu { get; set; }
        int SutGucu { get; set; }
        int KosuGucu { get; set; }

        void PasAt();
        void SutCek();
        void Kos();
        //void TopKurtar(); // Bu kalecinin özelliğidir. Forvette bunun bir karşılığı olamaz. O yüzden yanlış bir tasarım yapmış olduk. Bunu burdan kaldırıp IKaleciye al.
    }
}
