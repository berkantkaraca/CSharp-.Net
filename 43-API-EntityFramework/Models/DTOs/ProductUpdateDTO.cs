namespace _43_API_EntityFramework.Models.DTOs
{
    public record ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; init; } = default!;
        public decimal Price { get; init; }
        public string? Description { get; init; }
        public int CategoryId { get; init; }
    }
}
