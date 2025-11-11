namespace _41_EntityFramework_LoadingType.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } //navigation property'ler  virtual tanımlanmalı
    }
}
