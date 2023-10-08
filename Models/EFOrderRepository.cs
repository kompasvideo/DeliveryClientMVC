namespace DeliveryClientMVC.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly DeliveryOrderDb context;

        public EFOrderRepository(DeliveryOrderDb ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders;

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
            Order orderEdit = context.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            orderEdit.Date = order.Date;
            orderEdit.Shipper = order.Shipper;
            orderEdit.Consignee = order.Consignee;
            orderEdit.Cargo = order.Cargo;
            context.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            Order order = Orders.FirstOrDefault(o => o.OrderId == id);
            return order;
        }

        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order.NewOrder = true;
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
                    dbEntry.NewOrder = true;
                }
            }
            context.SaveChanges();
        }

        public IEnumerable<Order> SearchOrder(string text)
        {
            List<Order> orders = context.Orders.ToList();
            IEnumerable<Order> res = from order in orders
                     where order.Shipper.ToLower().Contains(text.ToLower()) 
                        || order.Consignee.ToLower().Contains(text.ToLower()) 
                        || order.Cargo.ToLower().Contains(text.ToLower())
                     select order;
            return res;
        }

    }
}
