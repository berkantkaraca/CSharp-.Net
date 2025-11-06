using System.Collections;

namespace _09_ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //tip ve boyut sınırlaması yoktur. listedki özellikler çalışır ama object beklediği için kullanırken boxing unboxing yapman lazım
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(1.5);

            foreach (var item in arrayList)
            {
                //int sonuc = item * 2; //hata verir. unboxing yapmak lazım

                //tip kontrolü ile işlem yapılabilir
                if (item.GetType() == typeof(int))
                {
                    int sonuc = (int)item * 2;
                    Console.WriteLine(sonuc);
                }

                //Not: nesnelerde kullanılan tip kontrolü. 
                //if (item as Person) 
                //{
                //    var result = item is Person
                //}

                Console.WriteLine(item);
            }
        }
    }
}
