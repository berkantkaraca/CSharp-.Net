namespace _26_Abstract
{
    public abstract class MuzikAleti
    {
        private string _marka;
        private string _aciklama;

        //Default değerler atamak için constructor yazılır
        public MuzikAleti(string marka, string aciklama)
        {
            Aciklama = aciklama;
            Marka = marka;
        }

        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }

        public string Marka
        {
            get { return _marka; }
            set { _marka = value; }
        }
        public string BilgiVer()
        {
            return $"Marka: {Marka} - Açıklama: {Aciklama}";
        }

        //Abstract metot: bu sınıftan kalıtım alan tüm sınıflarda bu metodun gövdesi tanımlanmalı
        public abstract string Call();

        //private abstract class tanımlanamaz. Mantığa ters. Alt sınıflara ilgili metodu dayatmak istiyoruz. protected veya public olabilr.
        //abstract metotlar abstract classlarda tanımlanır
        //abstract metot virtual tanımlanamaz. ztn virtual
        //abstract metot static tanımlanamaz. nesneye dayatma var
        //abstract metodun gövdesi olmaz
        //eylem odaklı iş mantıklarında da interface kullanılır
    }
}