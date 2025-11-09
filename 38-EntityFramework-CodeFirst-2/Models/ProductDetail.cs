namespace _38_EntityFramework_CodeFirst_2.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; } //Hem PK hem FK olacak. ProductConfig ve ProductDetailConfig de tanýmlandý.
        public string Description { get; set; }
        public string? Color { get; set; }
        public Product Product { get; set; }
    }
}
