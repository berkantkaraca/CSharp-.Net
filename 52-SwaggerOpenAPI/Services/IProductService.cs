using _52_SwaggerOpenAPI.Models.Product;

namespace _52_SwaggerOpenAPI.Services
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
