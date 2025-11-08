namespace _34_LINQ
{
    //Dto record yazılmalıdır. Sonradan değişemezsin. Immutability özelliği vardır. burda set yerine init kullanılır bu özellik için
    //record class, C#’ta veri odaklı (data-centric) nesneler oluşturmak için kullanılan özel bir türdür. record sınıfları immutable(değiştirilemez) veri taşıyıcıları üretmek için tasarlanmıştır.
    public record StudentDTO
    {
        public string Adi { get; init; }
        public string Sehir { get; set; }
    }
}
