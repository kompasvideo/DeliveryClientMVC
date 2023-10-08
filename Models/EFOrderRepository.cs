namespace DeliveryClientMVC.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly DeliveryOrderDb context;

        public EFOrderRepository(DeliveryOrderDb ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders 
        { 
            get
            {
                context.Couriers.ToList();
                context.Clients.ToList();
                return context.Orders;
            }
        }
        public Order DeleteOrder(int id)
        {
            Order order = context.Orders.FirstOrDefault(p => p.OrderId == id);
            if (order != null) 
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            return order;
        }

        public void EditOrder(Order order)
        {
            context.Couriers.ToList();
            context.Clients.ToList();
            Order orderEdit = context.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            orderEdit.Date = order.Date;
            orderEdit.Shipper = order.Shipper;
            orderEdit.Consignee = order.Consignee;
            orderEdit.Cargo = order.Cargo;
            context.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            context.Couriers.ToList();
            context.Clients.ToList();
            Order order = Orders.FirstOrDefault(o => o.OrderId == id);
            return order;
        }

        public void SaveOrder(Order order)
        {
            context.Couriers.ToList();
            context.Clients.ToList();
            if (order.OrderId == 0)
            {
                order.StatusOrder = StatusOrder.NEW;
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.FirstOrDefault(p => p.OrderId == order.OrderId);
                if (dbEntry != null)
                {
                    dbEntry.Shipper = order.Shipper;
                    dbEntry.Cargo = order.Cargo;
                    dbEntry.Consignee = order.Consignee;
                    dbEntry.Date = order.Date;
                    dbEntry.StatusOrder = StatusOrder.NEW;
                }
            }
            context.SaveChanges();
        }

        public IEnumerable<Order> SearchOrder(string text)
        {
            context.Couriers.ToList();
            context.Clients.ToList();
            List<Order> orders = context.Orders.ToList();
            IEnumerable<Order> res = from order in orders
                     where 
                     order.Shipper.Name.ToLower().Contains(text.ToLower()) 
                        || order.Consignee.Name.ToLower().Contains(text.ToLower()) 
                        || order.Cargo.ToLower().Contains(text.ToLower())
                     select order;
            return res;
        }

    }
}
