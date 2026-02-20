using _46_IoC_DependencyLifetime.Services.Concretes;
using _46_IoC_DependencyLifetime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _46_IoC_DependencyLifetime.Controllers
{
    public class GuidController : Controller
    {
        private readonly IGuidService _transient1;
        private readonly IGuidService _transient2;
        private readonly ScopedGuidService _scoped1;
        private readonly ScopedGuidService _scoped2;
        private readonly SingletonGuidService _singleton1;
        private readonly SingletonGuidService _singleton2;

        public GuidController(
            IGuidService transient1,
            IGuidService transient2,
            ScopedGuidService scoped1,
            ScopedGuidService scoped2,
            SingletonGuidService singleton1,
            SingletonGuidService singleton2)
        {
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }

        public IActionResult Index()
        {
            return Ok(new
            {
                Transient = new { g1 = _transient1.GetGuid(), g2 = _transient2.GetGuid() },
                Scoped = new { g1 = _scoped1.GetGuid(), g2 = _scoped2.GetGuid() },
                Singleton = new { g1 = _singleton1.GetGuid(), g2 = _singleton2.GetGuid() }
            });
        }
    }
}
