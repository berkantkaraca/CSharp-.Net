namespace _43_API_EntityFramework.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        //Relations
        public virtual ICollection<Product> Products { get; set; }
    }
}
