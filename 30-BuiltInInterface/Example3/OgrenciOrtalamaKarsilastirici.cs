namespace _30_BuiltInInterface.Example3
{
    public class OgrenciOrtalamaKarsilastirici : IComparer<Ogrenci>
    {
        public int Compare(Ogrenci? x, Ogrenci? y)
        {
            if (x == null || y ==null)
                throw new ArgumentNullException("Karsilastirilan degerler null olaramz");

            return x.Ortalama.CompareTo(y.Ortalama);
        }
    }
}
