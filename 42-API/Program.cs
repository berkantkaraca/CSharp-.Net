namespace _42_API
{
    public class Program
    {
        //get ile yazma işlemi de yapabiliriz. ama tercih edilmez => MÜLAKATTTTT
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Xml ile çalışmak için bu konfigrasyon yapılmalı
            builder.Services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            })
            .AddXmlDataContractSerializerFormatters();

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

            //merkezi routing işlemi. Apilerde çok tercih edilmez
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "api/{controller}/{action}/{id?}",
            //        defaults: new {controller = "Home", action = "Index"}
            //        );
            //});

            app.MapControllers();

            app.Run();
        }
    }
}
