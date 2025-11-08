namespace _26_Abstract
{
    public class Muzisyen
    {
        public Muzisyen(string adi, string soyadi)
        {
            Adi = adi;
            Soyadi = soyadi;
        }

        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public MuzikAleti CaldigiEnsturman { get; set; }
    }
}
