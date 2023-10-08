using DeliveryClientMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DeliveryClientMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DeliveryOrderDb>(options =>
               options.UseSqlServer(
                   builder.Configuration["Data:DeliveryOrder:ConnectionString"]));
            builder.Services.AddTransient<DeliveryOrderDb>();
            builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Order/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            SeedData.EnsurePopulated(app);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Order}/{action=Index}/{id?}");
            app.Run();
        }
    }
}