using CorrelationId;
using CorrelationId.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// https://localhost:7278/api/logs adresine X-Correlation-ID header'ı ile istek atıltığında aynı CID ile log oluşturur. Eğer header'da CID yoksa otomatik olarak yeni bir CID oluşturur ve loglara ekler.


//Bunlar appsettings.json dosyasından da okunabilir
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .Enrich.WithCorrelationId()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] [CID:{CorrelationId}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("Logs/app-log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Serilog'u uygulamanın logging sağlayıcısı olarak kullanmak için gerekli
builder.Host.UseSerilog();

// Diğer logging sağlayıcılarını temizleyerek sadece Serilog'u kullanır
builder.Logging.ClearProviders();

// Serilog'u logging sağlayıcısı olarak ekler
builder.Logging.AddSerilog();

// CorrelationId: Her isteğe özel benzersiz bir kimlik atamak için kullanılır. Bu, loglarda hangi isteklerin hangi loglarla ilişkili olduğunu anlamamıza yardımcı olur.
builder.Services.AddDefaultCorrelationId(options =>
{
    options.AddToLoggingScope = true; //CorrelationId'yi loga eklemek için
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// CorrelationId middleware'a ekleme
app.UseCorrelationId();

// Serilog'un request loglama middleware'ını ekleyerek her isteği loglamasını sağlar. Bu, isteklerin başlangıcında ve sonunda loglar oluşturur.
app.UseSerilogRequestLogging(); //Request loglama middleware'i

app.MapControllers();

app.Run();
