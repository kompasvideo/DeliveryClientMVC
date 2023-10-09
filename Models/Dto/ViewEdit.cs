namespace DeliveryClientMVC.Models
{
    public class ViewEdit
    {
        public Order Order { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}
