using System.Diagnostics.Metrics;
using System.Xml.Linq;

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
        IEnumerable<Client> GetClients();
        Client GetClientToName(string name);
        IEnumerable<Courier> GetCouriers();
        void TransferOrderSave(int id, string courier);
        void OrderDone(int id);
        void OrderCanceledSave(int id, string comments);
    }
}
