using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(o =>
{
    o.Limits.MaxRequestBodySize = 200_000_000; // 200MB
});

builder.Services.Configure<FormOptions>(o =>
{
    o.MultipartBodyLengthLimit = 200_000_000;
    o.ValueLengthLimit = 1 * 1024 * 1024;       // 1MB
    o.MultipartHeadersLengthLimit = 64 * 1024;  // 64KB
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();
