namespace _23_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Kalıtım-miras: Var olan kodun yeniden kullanılabilirliğini arttırmak ve yazılımın bakımını kolaylaştırmak için kullanılır
            //Parent - Super Class - Base Class: bu class'lardan davranış ve özellik bakımından kalıtım aldığımız sınıflara ise Child - Sub Class denir 

            Phone phone1 = new Phone("AEG");
            Console.WriteLine(phone1.GetInfo());
            Console.WriteLine(phone1.ToString());
            Console.WriteLine(phone1); //buda tostring olur
            Console.WriteLine(phone1.Call());

            Console.WriteLine("\n" + new string('*', 20) + "\n");

            MobilePhone phone2 = new MobilePhone("Nokia");
            phone2.HasCamera = true;
            phone2.IsTouched = true;
            //Console.WriteLine(phone2.GetInfo());
            Console.WriteLine(phone2);
            Console.WriteLine(phone2.Call());
            Console.WriteLine(phone2.TakePhoto());

            Console.WriteLine("\n" + new string('*', 20) + "\n");

            SmartPhone phone3 = new SmartPhone("Apple");
            phone3.HasCamera = true;
            phone3.IsTouched = true;
            phone3.FrontCam = true;
            //Console.WriteLine(phone3.GetInfo());
            Console.WriteLine(phone3);
            Console.WriteLine(phone3.Call());
            Console.WriteLine(phone3.DoVideoCall());
        }
    }
}
