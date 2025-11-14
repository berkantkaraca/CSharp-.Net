using _46_IoC_DependencyLifetime.Services;
using Microsoft.AspNetCore.Mvc;

namespace _46_IoC_DependencyLifetime.Controllers
{
    public class DateController : Controller
    {
        private readonly IShowDateTime _date1;

        public DateController(IShowDateTime date1)
        {
            _date1 = date1;
        }


        //Ekrana tarih yazılacak. Çalıştırdığın zaman saatleri Program.cs'de tanımladığın lifetime'a göre değişir.
        public IActionResult Index([FromServices] IShowDateTime _date2)
        {
            //Sayfaya her girdiğimde nesne oluşur. Dependency  Injection kullan.
            //IShowDateTime showDateTime = new ShowDateTime();
            //return Content(showDateTime.GetDateTime.ToString());

            var time1 = _date1.GetDateTime.TimeOfDay;
            var time2 = _date2.GetDateTime.TimeOfDay;

            return Content($"T1: {time1},\nT2: {time2}");
        }
    }
}
