namespace _43_API_EntityFramework.DTOs
{
    public record ProductDTO
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
        public string? Description { get; init; }

        //Relations
        public int CategoryId { get; init; }
    }
}
