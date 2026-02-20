using _46_IoC_DependencyLifetime.Services.Interfaces;

namespace _46_IoC_DependencyLifetime.Services.Concretes
{
    public class ShowDateTime : IShowDateTime
    {
        public DateTime GetDateTime { get; } = DateTime.Now;
    }
}
