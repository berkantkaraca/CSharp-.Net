using _55_RateLimiter.Models;
using _55_RateLimiter.Models.Product;

namespace _55_RateLimiter.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();

        ProductDto? GetById(int id);
        void Add(ProductSaveDto product);
        void Update(int id,ProductSaveDto product);
        void Delete(int id);
    }
}
