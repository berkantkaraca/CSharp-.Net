namespace _24_Inheritance_2
{
    internal class Program
    {
        static List<BaseMember> members = new List<BaseMember>()
        {
            new VipMember("F", "a", new DateTime(2025,10,22), "K"),
            new VipMember("s", "a", new DateTime(2025,10,22), "K"),
            new StandartMember("F", "a", new DateTime(2025,10,22)) { Kit = true}
        };

        static void Main(string[] args)
        {
            //BaseMember baseMember = new BaseMember(); //oluşturamaz hata verir
            Deneme deneme = new Deneme("a", "b", DateTime.Now); //breakpoint koyup nesne oluşumunu incele


            StandartMember standart1 = new StandartMember("a", "b", new DateTime(2025, 10, 25));
            standart1.Kit = true;
            Console.WriteLine(standart1);

            VipMember vip1 = new VipMember("a", "b", new DateTime(2025, 10, 22), "k");
            Console.WriteLine(vip1);

            List<BaseMember> list = new List<BaseMember>();
            list.Add(vip1);
            list.Add(standart1);

            //Tip dönüşümü yapmadan ilgili nesnenin tostringi çalıştırır.
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //Tip dönüşümü yapmadan ilgili nesnenin tostringi çalıştırır.
            foreach (var item in list)
            {
                if (item is VipMember)
                {
                    var result = item as VipMember; //dönüşüm yapıp ilgili nesneye ait olan proplarda gelir
                    //result.Coach;
                }
                else if (item.GetType() == typeof(StandartMember))
                {
                    var result = (StandartMember)item;
                    //result.Kit = true;
                }
            }

            Console.WriteLine("Üyelik sistemi");

            while (true)
            {
                Console.WriteLine("1-ekle 2-listele 3-çık");
                Console.Write("Seçim: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Adı: ");
                        string name = Console.ReadLine();

                        Console.Write("Soyadın: ");
                        string lastname = Console.ReadLine();

                        Console.Write("Başlangıç günü: ");
                        int day = int.Parse(Console.ReadLine());

                        Console.WriteLine("Üye tipi: A-vip B-stadart");
                        Console.Write("Seçim: ");
                        string input1 = Console.ReadLine();

                        if(input1 == "A")
                            members.Add(new VipMember(name, lastname, new DateTime(2025,10,21).AddDays(day),"K"));
                        else
                            members.Add(new StandartMember(name, lastname, new DateTime(2025, 10, 21).AddDays(day)));
                        break;

                    case "2":
                        Console.WriteLine("Üye tipi: A-vip B-stadart");
                        Console.Write("Seçim: ");
                        string input2 = Console.ReadLine();
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
