using _43_API_EntityFramework.AutoMappers;
using _43_API_EntityFramework.Contexts;
using _43_API_EntityFramework.Services;
using Microsoft.EntityFrameworkCore;

namespace _43_API_EntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddNewtonsoftJson();

            //IoC kaydı: DbContext her istekte yenilenmesin diye kayıt işlemi yapıldı
            //var conn = builder.Configuration.GetSection(""); //appsettings.json içindeki değerlere erişir
            var conn = builder.Configuration.GetConnectionString("DefaultConn");

            //builder.Services.AddDbContext<AppDbContext>(); //AppDbContext de boş constructor olsaydı
            builder.Services.AddDbContext<AppDbContext>(options =>
                options
                .UseSqlServer(conn)
                .UseLazyLoadingProxies()
            );

            //AutoMapper kayıt işlemi
            builder.Services.AddAutoMapper(typeof(ProductProfile));

            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
