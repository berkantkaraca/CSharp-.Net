using _54_Authorization.Models.Product;

namespace _54_Authorization.Services
{
    public class ProductService : IProductService
    {
        private static List<ProductDto> _products = new List<ProductDto>
        {
            new ProductDto { Id = 1, Name = "Laptop", Price = 25000m, Stock = 10 },
            new ProductDto { Id = 2, Name = "Mouse", Price = 500m, Stock = 50 },
            new ProductDto { Id = 3, Name = "Keyboard", Price = 1500m, Stock = 30 },
            new ProductDto { Id = 4, Name = "Monitor", Price = 8000m, Stock = 15 },
            new ProductDto { Id = 5, Name = "Headset", Price = 1200m, Stock = 25 }
        };

        private static int _nextId = 6;

        public void Add(ProductSaveDto product)
        {
            var newProduct = new ProductDto
            {
                Id = _nextId++,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
            _products.Add(newProduct);
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _products;
        }


        public ProductDto? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(int id, ProductSaveDto product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
            }
        }
    }
}
