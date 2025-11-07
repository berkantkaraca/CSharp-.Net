namespace _21_Struct
{
    public struct Color
    {
        // Struct Özellikleri:
        // - Değer tipidir, stack üzerinde tutulur.
        // - Parametreli constructor yazılabilir ama parametresiz constructor yazılamaz.
        // - Constructor, alanlara başlangıç değerleri atamak için kullanılır.
        // - Kalıtım (inheritance) alamaz, ama interface implemente edebilir.
        // - 'new' ile oluşturulduğunda bir kopyası (instance) oluşur. new'lendiğinde heap üzerinde değil stack üzerinde yer alır.
        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public void GetColor()
        {
            Console.WriteLine($"RGB: {Red}, {Green}, {Blue}");
        }
    }
}
//referans tiplerin değerleri heapte tutulur, değer tiplerin değerleri stackte tutulur