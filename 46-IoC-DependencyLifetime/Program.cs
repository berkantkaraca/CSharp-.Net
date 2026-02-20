using _46_IoC_DependencyLifetime.Services.Concretes;
using _46_IoC_DependencyLifetime.Services.Interfaces;

namespace _46_IoC_DependencyLifetime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Yaşam döngüsünü Dependency Injection sağlar. IOC bunu sağlar. Asp .Nette bu yapı bulunur. Pahalı olan nesneleri merkezi bir yerde newleyip ne kadar yaşayacağını belirleriz. 3 aşamalı: AddScoped, AddTransient, AddSingleton

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            //Nesnenin yaşam döngüleri:
            //Tansient: En temeli. Her talepte nesneyi yeniden oluşturur. Hafif tabanlı, sürekli yenilenmesi gereken süreçlerde kullanılır
            //https://localhost:7203/date sayfayı her yenilediğinde farklı saatler görürsün
            //builder.Services.AddTransient<ShowDateTime>(); //D.Inversion ihlali olur
            builder.Services.AddTransient<IShowDateTime, ShowDateTime>(); //IShowDateTime gördüğün zaman ShowDateTime nesnesini gönder

            //Scoped: Bir istek boyunca aynı nesneyi döndürür. Repo işlerinde (database) tercih edilir. 
            //https://localhost:7203/date sayfayı her yenilediğinde aynı saatleri görürsün
            builder.Services.AddScoped<IShowDateTime, ShowDateTime>();

            //Singleton: Uygulama boyunca aynı nesneyi döndürür. Genellikle konfigürasyon nesnelerinde kullanılır. Loglama mekanizması, SMS gönderme.
            //https://localhost:7203/date sayfayı her yenilediğinde program kapanana kadar aynı saatleri görürsün
            builder.Services.AddSingleton<IShowDateTime, ShowDateTime>();

            // Transient
            builder.Services.AddTransient<IGuidService, GuidService>();
            builder.Services.AddTransient<TransientGuidService>();

            // Scoped
            builder.Services.AddScoped<ScopedGuidService>();

            // Singleton
            builder.Services.AddSingleton<SingletonGuidService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Date}/{action=Index}/{id?}");

            app.Run();
        }
    }
}