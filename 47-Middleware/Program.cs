using Microsoft.AspNetCore.Authentication;
using _47_Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Kimlik doðrulama (fake)
builder.Services.AddAuthentication("BasicAuth")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuth", null);

// Yetkilendirme (header policy)
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HasXHeader", policy =>
    {
        policy.RequireAssertion(context =>
            context.Resource is HttpContext httpContext &&
            httpContext.Request.Headers.ContainsKey("X-Authorization"));
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowLocalhost");

app.MapControllers();

app.Run();
