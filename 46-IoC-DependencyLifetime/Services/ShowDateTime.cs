namespace _46_IoC_DependencyLifetime.Services
{
    public class ShowDateTime : IShowDateTime
    {
        public DateTime GetDateTime { get; } = DateTime.Now;
    }
}
