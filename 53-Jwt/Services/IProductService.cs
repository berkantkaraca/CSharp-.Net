using _53_Jwt.Models.Product;

namespace _53_Jwt.Services
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
