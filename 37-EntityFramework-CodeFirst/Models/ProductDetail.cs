namespace _37_EntityFramework_CodeFirst.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? Color { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } // Navigation Property
    }
}
