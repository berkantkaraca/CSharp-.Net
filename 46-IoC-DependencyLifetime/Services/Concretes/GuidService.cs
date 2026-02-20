using _46_IoC_DependencyLifetime.Services.Interfaces;

namespace _46_IoC_DependencyLifetime.Services.Concretes
{
    public class GuidService : IGuidService
    {
        private readonly string _guid = Guid.NewGuid().ToString();
        public string GetGuid() => _guid;
    }
}
