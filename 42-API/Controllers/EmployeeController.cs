using _42_API.Models;
using _42_API.Models.Route;
using _42_API.Repo;
using Microsoft.AspNetCore.Mvc;

namespace _42_API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [HttpGet("[action]")] //action ismi (metot ismi) ile de erişilebilir
        [HttpGet("All")]
        [HttpGet("AllEmployees")] //birden fazla route tanımlanabilir
        public ActionResult<List<Employee>> GetEmployees() //generic yapı kullandığımızda IActionResult yerine ActionResult yazılmalı
        {
            if (EmployeeData.Employees.Count < 0)
                return NotFound();

            return Ok(EmployeeData.Employees);
        }

        //[HttpGet("{id}")]
        [Route("{id:int:min(1):max(50):range(1,50)}")] //bu şekilde de route tanımlanabilir. int türünde id parametresi bekliyor. Apiyi gereksiz işlemlerden arındırır. paginationda kullanılabilir
        [HttpGet] //root yazılıdğı için burayı nitelendirmek için ekledik
        public ActionResult<Employee> GetEmployeesById([FromRoute] int id) 
        {
            var employee = EmployeeData.Employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
                return NotFound();
            
            return Ok(employee);
        }

        //alpha sadece karaktere izin verir. sayı girilmez
        //[HttpGet("gender/{gender:string:minlenght(3)}/city/{city:maxlenght(5):alpha}")]
        [HttpGet("gender/{gender}/city/{city}")]
        public ActionResult<List<Employee>> GetEmployeesByGenderAndCity([FromRoute] string gender, [FromRoute] string city)
        {
            var filteredEmployee = EmployeeData.Employees.Where(
                x => x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) 
                && x.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!filteredEmployee.Any()) //hiç eleman yoksa
                return NotFound();

            return Ok(filteredEmployee);
        }

        //birden fazla parametre alınca query string yapmak artık daha mantıklı
        [HttpGet("search")]
        public ActionResult<List<Employee>> SearchEmployees([FromQuery] EmployeeSearch searchCriteria)
        {
            var filteredEmployee = EmployeeData.Employees.AsEnumerable(); //birden fazla sorgu atacağımızdan yaptık

            if(!string.IsNullOrEmpty(searchCriteria.Gender))
                filteredEmployee = filteredEmployee.Where(e => e.Gender.Equals(searchCriteria.Gender, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(searchCriteria.Department))
                filteredEmployee = filteredEmployee.Where(e => e.Department.Equals(searchCriteria.Department, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(searchCriteria.City))
                filteredEmployee = filteredEmployee.Where(e => e.City.Equals(searchCriteria.City, StringComparison.OrdinalIgnoreCase));

            var result = filteredEmployee.ToList();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        //parametre almadan query string ile arama yapma
        //?Gender=male&Department=IT&City=Chicago postmanden bu isteği at
        [HttpGet("directsearch")]
        public ActionResult<List<Employee>> DirectSearch()
        {
            //HttpContext request ve response bilgilerine erişmemizi sağlar
            var Gender = HttpContext.Request.Query["gender"].ToString();
            var Department = HttpContext.Request.Query["department"].ToString();
            var City = HttpContext.Request.Query["city"].ToString();

            var filteredEmployee = EmployeeData.Employees.AsEnumerable();

            if (!string.IsNullOrEmpty(Gender))
                filteredEmployee = filteredEmployee.Where(e => e.Gender.Equals(Gender, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(Department))
                filteredEmployee = filteredEmployee.Where(e => e.Department.Equals(Department, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(City))
                filteredEmployee = filteredEmployee.Where(e => e.City.Equals(City, StringComparison.OrdinalIgnoreCase));

            var result = filteredEmployee.ToList();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet("page")]
        public IActionResult GetEmployeesPage([FromQuery] int page = 1)
        {
            const int pageSize = 5;
            int totalCount = EmployeeData.Employees.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var pagedData = EmployeeData.Employees
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //var result = new
            //{
            //    CurrentPage = page,
            //    TotalPages = totalPages,
            //    TotalCount = totalCount,
            //    PageSize = pageSize,
            //    Data = pagedData
            //};
            //return Ok(result);

            //Bunun yerine aşağıdaki kullanum çok daha doğru

            Response.Headers.Add("X-Current-Page", page.ToString());
            Response.Headers.Add("X-Total-Page", totalPages.ToString());
            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            Response.Headers.Add("X-Page-Size", pageSize.ToString());

            return Ok(pagedData);
        }

        [HttpPost]
        public IActionResult CreateEmploye([FromBody] Employee employee) //post default olarak FromBody den alır yazmana gerek yok
        {
            var emp = EmployeeData.Employees.FirstOrDefault(e => e.Id == employee.Id);

            if (emp != null)
                return BadRequest("Data mevcut");

            EmployeeData.Employees.Add(employee);

            return StatusCode(201, employee);
        }

        [HttpPost("submit-form")]
        public IActionResult SubmitForm([FromForm] Employee employee)
        {
            var emp = EmployeeData.Employees.FirstOrDefault(e => e.Id == employee.Id);

            if (emp != null)
                return BadRequest("Data mevcut");

            EmployeeData.Employees.Add(employee);

            return StatusCode(201, employee);
        }

        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm] FileUpload model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("File is missing");

            //FileStream operasyonuyla copy işlemi ile dosyayı kaydetme işlemi yapabilirsin
            return Ok(new
            {
                FileName = model.File.FileName,
                FileSize = model.File.Length,
                Description = model.Description
            });
        }

        //header kısmından parametre gösterimi
        [HttpGet("get-client-id")]
        public IActionResult GetClientId([FromHeader(Name = "X-Client-Id")] int clientId)
        {
            var employee = EmployeeData.Employees.FirstOrDefault(x => x.Id == clientId);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPut("{id}")] //Varsa mevcut kaynağı günceller yoksa ekleme yapılabilir. Post gibi de çalışır
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] EmployeeDTO model)
        {
            var emp = EmployeeData.Employees.FirstOrDefault(x => x.Id == id);

            if (emp == null)
                return NotFound();

            emp.Name = model.Name == "string" ? emp.Name : model.Name;
            //emp.Name = model.Name == default ? emp.Name : model.Name; //value tiplerde bu kullanılabilir. default değere göre kontrol eder
            emp.Department = model.Department ?? emp.Department;
            emp.City = model.City ?? emp.City;
            emp.Gender = model.Gender ?? emp.Gender;

            return Ok(emp);
        }
    }
}
