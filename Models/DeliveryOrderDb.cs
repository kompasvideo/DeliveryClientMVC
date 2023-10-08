using Microsoft.EntityFrameworkCore;

namespace DeliveryClientMVC.Models
{
    public class DeliveryOrderDb : DbContext
    {
        //public DbSet<Courier> Courier { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DeliveryOrderDb(DbContextOptions<DeliveryOrderDb> options) : base(options)
        {
        }
    }

}
