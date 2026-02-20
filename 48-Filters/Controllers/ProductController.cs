using _48_Filters.Filters;
using _48_Filters.Models.Product;
using _48_Filters.Services;
using Microsoft.AspNetCore.Mvc;

namespace _48_Filters.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ApiKeyAuthorizationFilter))] //ServiceFilter Kullanmak için program.cs de ilgili filtreleri eklememiz gerekiyor. TypFilter'da buna gerek yoktur.
    //[TypeFilter(typeof(ApiKeyAuthorizationFilter))]
    [ServiceFilter(typeof(ResourceLogFilter))]
    [ServiceFilter(typeof(ActionLogFilter))]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IProductService _productService;
        

        public ProductController(IProductService productService)
        {
            _productService=productService;
        }

        [HttpGet]
        [ServiceFilter(typeof(WrapResponseFilter))] // Action seviyesinde filtreleme
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }
        [HttpGet("GetAllFiltered")]
        public IActionResult GetAllFiltered(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sort = null,
            [FromQuery] string? search = null)
        {
            try
            {
                return Ok(_productService.GetPagedFilteredSorted(page, pageSize, sort, search));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {            
            if(id<=0)
            throw new ArgumentException("Geçersiz ID!");

            var product= _productService.GetById(id);
            return product==null?NotFound():Ok(product);           
        }

        [HttpPost]
        public IActionResult Add(ProductSaveDto product)
        {
            try
            {
                _productService.Add(product);
                return CreatedAtAction(nameof(GetById),product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,ProductSaveDto product)
        {
            try
            {
                _productService.Update(id,product);
                return NoContent();
            }
            catch (Exception ex)
            {
                if(ex.Message=="Ürün bulunamadı")
                {
                    return NotFound();
                }
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Ürün bulunamadı")
                {
                    return NotFound();
                }
                return BadRequest();
            }
        }
    }
}
