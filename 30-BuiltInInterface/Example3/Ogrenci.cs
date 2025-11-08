namespace _30_BuiltInInterface.Example3
{
    public class Ogrenci : IComparable<Ogrenci>, IEquatable<Ogrenci>, ICloneable
    {
        public string Ad { get; set; }
        public double Ortalama { get; set; }

        //IComparable: 0 dönerse nesne eşit, pozitif dönerse değerinden büyüktür, negatifse değerinden küçüktür
        public int CompareTo(Ogrenci? other)
        {
            if (other == null) 
                return 1;
            return other.Ad.CompareTo(Ad);
        }

        //IEquatable: eşitlik kontrolü yapar
        public bool Equals(Ogrenci? other)
        {
           if(other == null) return false;

           //return this.Ad == other.Ad;
           return Ad.Equals(other.Ad);

           //return string.Compare(this.Ad, other.Ad, StringComparison.OrdinalIgnoreCase); //büyükten küçüğe sıralar
        }

        //2. yöntem - objeden karşılaştırma
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var ogrenci = (Ogrenci)obj;
            return this.Ad == ogrenci.Ad;
        }

        //referans adresine göre numara üretir. equalsı override ettiysen bunu da yap
        public override int GetHashCode()
        {
            return Ad.GetHashCode();
        }

        //ICloneable: kopyalama işleminde karşımıza çıkar
        public object Clone()
        {
            return new Ogrenci() { Ad = Ad, Ortalama = Ortalama };
        }
    }
}
