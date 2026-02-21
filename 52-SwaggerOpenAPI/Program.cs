using _52_SwaggerOpenAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();// Swagger için gerekli olan endpoint keşif hizmetini ekler.

// Swagger/OpenAPI belgelerini oluşturmak için gerekli olan hizmeti ekler.
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

//swagger jwt konfigürasyonu
//builder.Services.AddSwaggerGen(c =>
//{
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Bearer (token)",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer"
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//            },
//            Array.Empty<string>()
//        }
//    });
//});

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger/OpenAPI belgelerini oluşturmak için gerekli olan ara yazılımı ekler.
    app.UseSwaggerUI(); // Swagger/OpenAPI belgelerini görselleştirmek ve test etmek için gerekli olan ara yazılımı ekler.
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
