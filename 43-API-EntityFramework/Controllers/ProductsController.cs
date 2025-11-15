using _43_API_EntityFramework.Models.DTOs;
using _43_API_EntityFramework.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace _43_API_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var dtos = await _service.GetAllAsync();
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanından veri çekilemedi!", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            try
            {
                var (dto, etag) = await _service.GetByIdAsync(id);

                if (dto == null)
                    return NotFound($"{id} nolu ürün bulunamadı!");

                if (!string.IsNullOrEmpty(etag))
                    Response.Headers.ETag = etag;

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanından veri çekilemedi!", Details = ex.Message });
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetAllProduct(
            [FromQuery] string? q,
            [FromQuery] int? categoryId,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] string? sort = "name_asc",
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 5
            )
        {
            try
            {
                var result = await _service.GetFilteredAsync(q, categoryId, minPrice, maxPrice, sort, pageIndex, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanından veri çekilemedi!", Details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO productDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var (dto, etag) = await _service.CreateAsync(productDTO);
                Response.Headers.ETag = etag;

                //Ekledikten sonra GetProductById ye yönlendirdik.
                return CreatedAtAction(nameof(GetProductById), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanına veri eklenemedi!", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDTO dto)
        {
            try
            {
                var ifMatch = Request.Headers["If-Match"].ToString();

                var (success, error) = await _service.UpdateAsync(id, dto, ifMatch);

                if (!success)
                {
                    return error switch
                    {
                        "not_found" => NotFound($"{id} nolu product bulunamadı"),
                        "etag_missing" => StatusCode(428, "E-tag zorunludur"),
                        "etag_mismatch" => StatusCode(412, "E-tag yapısı değişmiş"),
                        "_" => StatusCode(400, "Güncelleme yapılamadı")
                    };
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanına veri güncellenemedi!", Details = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduct(int id, [FromBody] JsonPatchDocument<ProductPatchDTO> patch)
        {
            try
            {
                var ifMatch = Request.Headers["If-Match"].ToString();

                var (success, error) = await _service.PatchAsync(id, patch, ifMatch);

                if (!success)
                {
                    return error switch
                    {
                        "not_found" => NotFound($"{id} nolu product bulunamadı"),
                        "etag_missing" => StatusCode(428, "E-tag zorunludur"),
                        "etag_mismatch" => StatusCode(412, "E-tag yapısı değişmiş"),
                        "_" => StatusCode(400, "Güncelleme yapılamadı")
                    };
                }

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanına veri güncellenemedi!", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var success = await _service.SoftDeleteAsync(id);
                if (!success)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanına veri silinemedi!", Details = ex.Message });
            }
        }

        [HttpHead("{id}")]
        public async Task<IActionResult> HeadProduct(int id)
        {
            var etag = await _service.GetEtagAsync(id);
            if (etag == null)
                return NotFound();

            Response.Headers.ETag = etag;
            Response.Headers.Append("X-Resource-Id", id.ToString());
            return Ok();
        }

        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS, HEAD");
            return Ok();
        }
    }
}
