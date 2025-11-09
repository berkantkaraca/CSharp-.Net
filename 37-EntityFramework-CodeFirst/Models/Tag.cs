namespace _37_EntityFramework_CodeFirst.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
