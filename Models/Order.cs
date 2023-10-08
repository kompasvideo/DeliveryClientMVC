using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DeliveryClientMVC.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        /// <summary>
        /// дата
        /// </summary>
        public string? Date { get; set; }
        public int? ShipperInfoKey { get; set; }
        /// <summary>
        /// грузоотправитель
        /// </summary>
        [ForeignKey("ShipperInfoKey")]
        public Client Shipper { get; set; }
        public int? ConsigneeInfoKey { get; set; }
        /// <summary>
        /// грузополучатель
        /// </summary>
        [ForeignKey("ConsigneeInfoKey")] 
        public Client Consignee { get; set; }
        /// <summary>
        /// груз
        /// </summary>
        public string? Cargo { get; set; }
        public StatusOrder StatusOrder { get; set; }
        [MaybeNull]
        public int? CourierInfoKey { get; set; }
        [MaybeNull]
        [ForeignKey("CourierInfoKey")]
        public Courier Courier { get; set;}
    }
}
