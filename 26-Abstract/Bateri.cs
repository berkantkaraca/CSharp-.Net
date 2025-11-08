namespace _26_Abstract
{
    public class Bateri : MuzikAleti
    {
        public Bateri(string marka, string aciklama) : base(marka, aciklama)
        {
        }

        //Call metodunun davranışı alt sınıfta belirlenöiş olur
        public override string Call()
        {
            return "Bateri";
        }
    }
}
