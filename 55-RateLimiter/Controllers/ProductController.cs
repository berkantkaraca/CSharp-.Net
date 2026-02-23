using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using _55_RateLimiter.Exceptions;
using _55_RateLimiter.Models;
using _55_RateLimiter.Models.Product;
using _55_RateLimiter.Services;
using System.Security.Claims;

namespace _55_RateLimiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        /// <summary>
        /// Tüm ürünleri listeler
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        [HttpGet("GetAll/{companyId}")]
        //[EnableRateLimiting("fixed")]
        [EnableRateLimiting("user-sliding")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        [ProducesResponseType(typeof(NoData), 400)]
        public IActionResult GetAll(int companyId)
        {
            try
            {
                var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName=User.FindFirstValue("name");
                //var product=User.FindFirstValue("product");

                //if (product != "true")
                //    return Forbid();

                _logger.LogInformation("GetAll fetched at {time}", DateTime.Now);
                return Ok(_productService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        /// <summary>
        /// Belirli bir ürünü döner.
        /// </summary>
        /// <param name="id">Ürün benzersiz numarası</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NotFoundException"></exception>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {            
            if(id<=0)
            throw new ArgumentException("Geçersiz ID!");

            if (id == 1)
                throw new NotFoundException("");

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
