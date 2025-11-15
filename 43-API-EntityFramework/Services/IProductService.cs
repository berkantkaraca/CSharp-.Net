using _43_API_EntityFramework.Models.DTOs;
using _43_API_EntityFramework.Models.Filters;
using Microsoft.AspNetCore.JsonPatch;

namespace _43_API_EntityFramework.Services
{
    public interface IProductService
    {
        //async: aynı anda birden fazla işi yapar.
        Task<List<ProductReadDTO>> GetAllAsync();
        Task<(ProductReadDTO? Dto, string? ETag)> GetByIdAsync(int id);
        Task<PaginatedList<ProductReadDTO>> GetFilteredAsync(string? q, int? categoryId, decimal? minPrice, decimal? maxPrice, string? sort, int pageIndex, int pageSize);
        Task<(ProductReadDTO, string? ETag)> CreateAsync(ProductCreateDTO dto);
        Task<(bool Success, string ErrorCode)> UpdateAsync(int id, ProductUpdateDTO dto, string? ifMatchEtag);
        Task<(bool Success, string ErrorCode)> PatchAsync(int id, JsonPatchDocument<ProductPatchDTO> patchDoc, string? ifMatchEtag);
        Task<bool> SoftDeleteAsync(int id);
        Task<string?> GetEtagAsync(int id);
    }
}
