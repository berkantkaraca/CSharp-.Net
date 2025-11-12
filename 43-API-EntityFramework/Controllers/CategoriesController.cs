using _43_API_EntityFramework.Contexts;
using _43_API_EntityFramework.DTOs;
using _43_API_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace _43_API_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            try
            {
                var categories = _context.Categories.ToList();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veri Çekilemedi", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById([FromRoute] int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.Id == id);

                if (category == null)
                    return NotFound(new { Message = $"{id} nolu ürün bulunamadı" });

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veri Çekilemedi", Details = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Category category = new Category() { Name = categoryDTO.Name };

                _context.Categories.Add(category);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"veri eklenemedi", Details = ex.Message });
            }
        }
    }
}
