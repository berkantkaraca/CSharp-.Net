namespace _32_Relationship
{
    public class Engine
    {
        public Engine(string model, decimal horsePower)
        {
            Model = model;
            HorsePower = horsePower;
        }

        public string Model { get; set; }
        public decimal HorsePower { get; set; }

        public void Start()
        {
            Console.WriteLine($"{Model} {HorsePower} start");
        }

        public void Stop()
        {
            Console.WriteLine($"{Model} {HorsePower} stop");
        }
    }

    public class MusicSystem
    {
        public string Brand { get; set; }

        public MusicSystem(string brand)
        {
            Brand = brand;
        }

        public void PlayMusic()
        {
            Console.WriteLine($"{Brand} playy");
        }
    }

    public class Car
    {
        //Engine olmadan nesne başlatılmaz. is part of ilişkisi var. musicsystem opsiyonel
        public Car(string brand, Engine engine)
        {
            Brand = brand;
            Engine = engine;
        }

        public string Brand { get; set; }
        public Engine Engine { get; set; } //Composition: Bir nesne diğer nesnenin zorunlu bir parçasıdır. Ana nesne silinirse, parça da silinir. "is part of" ilişkisi.
        public MusicSystem MusicSystem { get; set; } //Aggregation: Bir nesne diğer nesneyi opsiyonel olarak içerir. Ana nesne silinse bile diğeri var olabilir. "has a" ilişkisi.

        public void StartCar()
        {
            Console.WriteLine($"{Brand} car start");
            Engine.Start();
            MusicSystem?.PlayMusic();
        }
    }
}
