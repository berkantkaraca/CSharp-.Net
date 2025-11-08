namespace _26_Abstract
{
    public class Gitar : MuzikAleti
    {
        public Gitar(string marka, string aciklama) : base(marka, aciklama)
        {
        }

        public override string Call()
        {
            return "Gitar";
        }
    }
}
