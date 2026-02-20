using Microsoft.EntityFrameworkCore;
using _48_Filters;
using _48_Filters.Filters;
using _48_Filters.Profiles;
using _48_Filters.Repository;
using _48_Filters.Services;

var builder = WebApplication.CreateBuilder(args);

/*
middleware'ler http seviyesinde çalışır 
filter'lar mvc seviyesinde çalışır (controller, action)

"Filtreler, middleware'den sonra gelen ikinci savunma hattıdır.
Authorization erişimi, Resource performansı, Action iş akışını, Result yanıtı, Exception da hataları kontrol eder."

IAuthorizationFilter: Action çalışmadan önce yetkilendirme kontrolü yapar; kullanıcı erişim hakkına sahip değilse pipeline’ı durdurur.

IResourceFilter: Model binding ve action’dan önce/sonra çalışarak request’in erken aşamalarında cache, performans veya kaynak yönetimi gibi işlemleri yapar.

IActionFilter: Action method çalışmadan hemen önce ve çalıştıktan hemen sonra devreye girerek logging, validation veya veri manipülasyonu gibi işlemler yapar.

IResultFilter: Action sonucu üretildikten sonra response client’a gönderilmeden önce/sonra çalışarak sonucu değiştirme veya ek işlem yapma imkanı sağlar.
 
 */

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

builder.Services.AddScoped<ApiKeyAuthorizationFilter>();
builder.Services.AddScoped<ResourceLogFilter>();
builder.Services.AddScoped<ActionLogFilter>();
builder.Services.AddScoped<WrapResponseFilter>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
