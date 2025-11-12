using _43_API_EntityFramework.Contexts;
using _43_API_EntityFramework.DTOs;
using _43_API_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _43_API_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //IoC olmasaydı her fonksiyonda bu şekilde oluşturma yapacaktık. Veya constructorda oluştursan alt metotlarda kullanılacktı. Her türlü performan açısından zararlı. IoC de newleme yaptık ve her yerde bu context nesnesini kullanacağız.
        //public void Add()
        //{
        //    AppContext context = new AppContext();
        //}

        private readonly AppDbContext _context;

        //Constructor IoC den contexti çeker ve referansını _contexte atar
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            try
            {
                var products = _context.Products.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veri Çekilemedi", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == id);

                if (product == null)
                    return NotFound(new { Message = $"{id} nolu ürün bulunamadı" });

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veri Çekilemedi", Details = ex.Message });
            }
        }

        [HttpGet("filter")]
        public IActionResult GetAllProduct(
            [FromQuery] string q, //search
            [FromQuery] int? categoryId,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] string? sort = "name_asc", // name_asc, name_dex, price_asc, price_desc 
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 5
            )
            //model binding daha hoş olurdu
        {
            //Sorguyu direkt veritabanına atacağımdan IQueryable kullandım, eğer tüm dataları çekip işlem yapsaydım IEnumerable kullanırdım
            IQueryable<Product> query = _context.Products
                .Include(p => p.Category) //prductlarla birlikte categoryde gelsin
                .AsNoTracking(); //Category ile birleştirdik zaten. gelen datayla da işlem yapmayacağım o yüzden trackingi kapadık

            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(p => p.Name.Contains(q) || p.Description != null || p.Description.Contains(q));

            if (categoryId is not null)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (minPrice is not null)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice is not null)
                query = query.Where(p => p.Price <= maxPrice.Value);

            query = sort switch
            {
                "name_desc" => query.OrderByDescending(p => p.Name),
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name) // default: name_asc
            };

            int total = query.Count(); //ana query sorgusu daha gitmez. burda count için ayrı bir sorgu atar  
            var items = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList(); //ana sorgu atılır

            return Ok(new
            {
                Count = total,
                Page = pageIndex,
                Size = pageSize,
                TotalPages = (int)Math.Ceiling(total / (double)pageSize),
                Data = items
            });
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                Product  product = new Product()
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    Description = productDTO.Description,
                    CategoryId = productDTO.CategoryId,
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                //Ekledikten sonra GetProductById ye yönlendirdik.
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"veri eklenemedi", Details = ex.Message });
            }
        }
    }
}
