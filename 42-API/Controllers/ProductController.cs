using Microsoft.AspNetCore.Mvc;

namespace _42_API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //İstek örnekleri:
        //products
        //products/101?category=201

        private static List<string> _products = new List<string>()
        {
            "Mause", "Keyboard"
        };

        //[HttpGet, HttpPost] // birden fazla istek türünü karşılayabilir
        [HttpGet]
        [HttpGet("[action]")] //=> action metot ismini çeker
        public IActionResult Products([FromBody] int id)
        {
            //[FromBody] int id //id gelen isteğin bodysinden alınır
            //[FromForm] => formdan alır
            //[FromHeader] => headerdan alır
            //[FromQuery] => ?key=value
            //[FromRoute] => /products/

            NotFound();
            BadRequest();
            StatusCode(200, _products); //kodu ve datayı döner
            Content("Hello"); //string döner
            Redirect("https://www.google.com"); //yönlendirme yapar

            return Ok(_products);
        }

        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            if (_products == null || _products.Count <= 0)
                return NoContent();

            return Ok(_products);
        }

        //Route Parameter
        [HttpGet("{id}")]
        public IActionResult GetAllProductById([FromRoute] int id)
        {
            if (_products == null || id >= _products.Count)
                return NotFound("Ürün bulunamadı"); //404

            return Ok(_products[id]); //200
        }

        //Query String ile id alma
        [HttpGet("id")]
        public IActionResult GetAllProductById2([FromQuery] int id)
        {
            if (_products == null || id >= _products.Count)
                return NotFound("Ürün bulunamadı"); //404

            return Ok(_products[id]); //200
        }
    }
}
