using _48_Filters.Models;
using _48_Filters.Models.Product;

namespace _48_Filters.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();

        ProductDto? GetById(int id);
        void Add(ProductSaveDto product);
        void Update(int id, ProductSaveDto product);
        void Delete(int id);
        Result<Product> GetPagedFilteredSorted(int page, int pageSize, string? sort, string? search);
    }
}
