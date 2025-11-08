namespace _26_Abstract
{
    public class Fulut : MuzikAleti
    {
        public Fulut(string marka, string aciklama) : base(marka, aciklama)
        {
        }

        public override string Call()
        {
            return "Fülüt";
        }
    }
}
