namespace DeliveryClientMVC.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Order DeleteOrder(int id);
        void SaveOrder(Order order);
        IEnumerable<Order> SearchOrder(string text);
        Order GetOrderById(int id);
        void EditOrder(Order order);
    }
}
