using _54_Authorization.Models.Product;

namespace _54_Authorization.Services
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
