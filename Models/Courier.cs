using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeliveryClientMVC.Models
{
    public class Courier
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourierId { get; set; }
        public string Name { get; set; }
        public List<Order> Order { get; set; }
    }
}
