using System.Collections;

namespace _30_BuiltInInterface.Example1
{
    //Liste gibi çalışan yapı yapacağız o yüzden IEnumarable ekledik. IE<> generic üzerinden, IE olarak çıkan object üzerinden çalışır
    public class Kitaplık : IEnumerable<Kitap>
    {
        private List<Kitap> kitaplar = new List<Kitap>();

        public void KitapEkle(Kitap kitap)
        {
            kitaplar.Add(kitap);
        }

        //Yineleme işlemini yapan metot. foreach'deki iterasyonu sağlayan yapı. Koleksiyonun yineleyicisini döndürerek foreach içinde gezinmesini sağlar.
        public IEnumerator<Kitap> GetEnumerator()
        {
            //return kitaplar.GetEnumerator(); //returnde çalışan yapı aşağıdakidir

            foreach (var item in kitaplar)
            {
                yield return item; //yield: tüm listeyi tekte belleğe yüklemeden döngünün her iterasyonunda belleğe yükler. lazy loading sağlar
            }
        }

        //Type-Safe (tip güvenliği) sağlar
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
