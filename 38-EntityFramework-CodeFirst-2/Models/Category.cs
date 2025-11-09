namespace _38_EntityFramework_CodeFirst_2.Models
{
    public class Category
    {
        public Category()
        {
        }
        public Category(string name)
        {
            Name = name;
        }
        
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
