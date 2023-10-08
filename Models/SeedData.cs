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
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<Client> clients = new List<Client>()
                {
                    new Client
                        {
                            Name = "Москва"
                        },
                        new Client
                        {
                            Name = "Минск"
                        },
                        new Client
                        {
                            Name = "Орёл"
                        }
                };

                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(clients);
                }
                List<Courier> couriers = new List<Courier>()
                {
                    new Courier
                    {
                        Name = "Курьер_1"
                    },
                    new Courier
                    {
                        Name = "Курьер_2"
                    },
                    new Courier
                    {
                        Name = "Курьер_3"
                    },
                    new Courier
                    {
                        Name = "Курьер_4"
                    },
                };
                if (!context.Couriers.Any())
                {
                    context.Couriers.AddRange(couriers);
                }
                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(
                    new Order
                    {
                        Shipper = clients[0],
                        Consignee = clients[1],
                        Cargo = "Товар_1",
                        Date = "17.01.2023",
                        StatusOrder = StatusOrder.NEW,
                        Courier = null
                    }, new Order
                    {
                        Shipper = clients[1],
                        Consignee = clients[0],
                        Cargo = "Товар_2",
                        Date = "18.02.2023",
                        StatusOrder = StatusOrder.NEW,
                        Courier = null
                    },
                    new Order
                    {
                        Shipper = clients[1],
                        Consignee = clients[2],
                        Cargo = "Товар_3",
                        Date = "03.01.2023",
                        StatusOrder = StatusOrder.NEW,
                        Courier = null
                    },
                    new Order
                    {
                        Shipper = clients[2],
                        Consignee = clients[1],
                        Cargo = "Товар_4",
                        Date = "04.01.2023",
                        StatusOrder = StatusOrder.NEW,
                        Courier = null
                    }); 
                    context.SaveChanges();
                }
            }
        }
    }
}
