using _50_Configuration_OptionsPattern.Models;
using _50_Configuration_OptionsPattern.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

// appsettings.json dosyasını zorunlu olarak yükler ve dosyada değişiklik olursa uygulama çalışırken yeniden okur.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Eğer ortam Development ise ayrıca appsettings.Development.json dosyasını yükler.
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}

var config = builder.Configuration;
string connection = config.GetConnectionString("DefaultConnection") ?? "";
string appName = config["AppSettings:ApplicationName"] ?? "";
string version = config["AppSettings:Version"] ?? "";

Console.WriteLine(appName);
Console.WriteLine(version);

// Options pattern: AppSettings sını yapılandırma dosyasından okuyarak uygulama genelinde kullanılabilir hale getirir.
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IConfigCompareService, ConfigCompareService>();

builder.Services.AddSingleton<ConfigMonitorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// ConfigMonitorService'i uygulama başlatıldığında çalıştırarak yapılandırma değişikliklerini izlemeye başlar.
_ = app.Services.GetRequiredService<ConfigMonitorService>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
