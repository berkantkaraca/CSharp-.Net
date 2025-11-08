namespace _26_Abstract
{
    public class MuzikGrubu
    {
        public MuzikGrubu(string grubAdi)
        {
            GrubAdi = grubAdi;
        }
        
        public string GrubAdi { get; set; }
        public List<Muzisyen> Calgicilar { get; set; } = new List<Muzisyen>();
    }
}
