using Microsoft.EntityFrameworkCore;

namespace DeliveryClientMVC.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider.GetRequiredService<DeliveryOrderDb>;
                DeliveryOrderDb context = services.Invoke();
                if (context.Database.GetPendingMigrations().Any())
                {
                    //context.Database.Migrate();
                }
                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(
                    new Order
                    {
                        Shipper = "Москва",
                        Consignee = "Санкт-Петербург",
                        Cargo = "Товар_1",
                        Date = "17.01.2023"
                    }, new Order
                    {
                        Shipper = "Тула",
                        Consignee = "Москва",
                        Cargo = "Товар_2",
                        Date = "18.02.2023"
                    },
                    new Order
                    {
                        Shipper = "Орёл",
                        Consignee = "Санкт-Петербург",
                        Cargo = "Товар_3",
                        Date = "03.01.2023"
                    },
                    new Order
                    {
                        Shipper = "Екатеринбург",
                        Consignee = "Тверь",
                        Cargo = "Товар_4",
                        Date = "04.01.2023"
                    });
                    context.SaveChanges();
                }                
            }
        }
    }
}
