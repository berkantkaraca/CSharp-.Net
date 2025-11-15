namespace _43_API_EntityFramework.Models.DTOs
{
    public record ProductReadDTO
    {
        public int Id { get; set; }
        public string Name { get; init; } = default!;
        public decimal Price { get; init; }
        public string? Description { get; init; }
        public int CategoryId { get; init; }
        public string CategoryName { get; init; }
        public string ETag { get; init; }
    }
}
