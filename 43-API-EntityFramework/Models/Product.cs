using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace _43_API_EntityFramework.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!; //null geçilemez
        public decimal Price { get; set; }
        public string? Description { get; set; }

        //Relations
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //SoftDelete
        public bool IsDeleted { get; set; } = false; //Enum kullanarak da yapılabilir

        //Concurrency Token (ETag üretmek için kullanacağız) Sunucu tabanlı programlamalarda iki kişinin aynı işlemi yaparken aradaki senkronizasyonu düzenlemek için kullanılır. “birden fazla kullanıcı aynı veriyi aynı anda değiştirirse çakışma olmasın” mantığına dayanır.
        //Veritabanı tarafında sütun oluşacak ve 8 byte'lık bir token atanacak ve bunun üzerinden kontrol edilir
        public byte[] RowVersion { get; set; } = default!;
    }
}
