namespace _26_Abstract
{
    internal class Program
    {
        //abstract: override işine gerek kalmdan davranışı ezmek yerine davranışı alt sınıfta tanımlanmış olur
        //Base class'tan instance alınmayacaksa abstract tanımlanır.
        //abstract classlardan instance oluşturulamaz.
        static void Main(string[] args)
        {
            Bateri bateri1 = new Bateri("Marshall", "Kalite");
            Console.WriteLine(bateri1.BilgiVer());
            Console.WriteLine("Ses: " + bateri1.Call());

            Gitar gitar1 = new Gitar("Yamaha", "Pro");
            Console.WriteLine(gitar1.BilgiVer());
            Console.WriteLine("Ses: " + gitar1.Call());

            Muzisyen muzisyen1 = new Muzisyen("F", "A");
            muzisyen1.CaldigiEnsturman = gitar1;

            Muzisyen muzisyen2 = new Muzisyen("V", "A");
            muzisyen2.CaldigiEnsturman = gitar1;

            Muzisyen muzisyen3 = new Muzisyen("f", "A");
            muzisyen3.CaldigiEnsturman = new Fulut("Redmi", "Amator");

            Muzisyen muzisyen4 = new Muzisyen("V", "A");
            muzisyen4.CaldigiEnsturman = bateri1;

            MuzikGrubu muzikGrubu = new MuzikGrubu("Bilge Çalgıcıları");
            muzikGrubu.Calgicilar.Add(muzisyen2);
            muzikGrubu.Calgicilar.Add(muzisyen3);
            muzikGrubu.Calgicilar.Add(muzisyen4);

            int a = 2024;

            foreach (var item in muzikGrubu.Calgicilar)
            {
                Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Müzisyen: " + item.Adi);
                Console.Write("\t" + item.CaldigiEnsturman.BilgiVer());
                Console.WriteLine(" " + item.CaldigiEnsturman.Call());
                Console.Beep();
            }
        }
    }
}
