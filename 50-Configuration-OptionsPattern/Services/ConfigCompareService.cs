using Microsoft.Extensions.Options;
using _50_Configuration_OptionsPattern.Models;

namespace _50_Configuration_OptionsPattern.Services
{
    public class ConfigCompareService : IConfigCompareService
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<AppSettings> _options;
        private readonly IOptionsSnapshot<AppSettings> _optionsSnapshot;
        private readonly IOptionsMonitor<AppSettings> _optionsMonitor;

        /*
        IOptions<T>: Uygulama başlatıldığında yapılandırma dosyasından AppSettings sınıfını okuyarak bir kez yükler ve uygulama boyunca aynı değerleri sağlar. Değişiklikleri izlemez.
        Uygulama appsettings.json dosyasını 1 kere okur ve AppSettings sınıfına map eder.

        IOptionsSnapshot<T>: Her HTTP isteği için yapılandırma dosyasından AppSettings sınıfını yeniden okuyarak güncel değerleri sağlar. Değişiklikleri izler.
        Uygulama her HTTP isteği geldiğinde appsettings.json dosyasını yeniden okur ve AppSettings sınıfına map eder.

        IOptionsMonitor<T>: Uygulama çalışırken yapılandırma dosyasındaki değişiklikleri izler ve güncel AppSettings değerlerini sağlar. Değişiklikleri izler.
        OnChange fomksiyonu değişiklik yapıldığında tetiklenir ve yeni değerleri sağlar.

        Configuration: "reloadOnChange: true" tanımlandığı için IOptionsSnapshot gibi davranır ama tip güvenliği sağlamaz. Değişiklikleri izler ve güncel değerleri sağlar.
        */
        public ConfigCompareService(IConfiguration configuration, IOptions<AppSettings> options, IOptionsSnapshot<AppSettings> optionsSnapshot, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _configuration = configuration;
            _options = options;
            _optionsSnapshot = optionsSnapshot;
            _optionsMonitor = optionsMonitor;
        }
        public object GetConfigCompare()
        {
            return new
            {
                Configuration = new { version = _configuration["AppSettings:Version"], appName = _configuration["AppSettings:ApplicationName"] },
                Options = new { version = _options.Value.Version, appName = _options.Value.ApplicationName },
                OptionsSnapshot = new { version = _optionsSnapshot.Value.Version, appName = _optionsSnapshot.Value.ApplicationName },
                OptionsMonitor = new { version = _optionsMonitor.CurrentValue.Version, appName = _optionsMonitor.CurrentValue.ApplicationName }
            };
        }
    }
}
