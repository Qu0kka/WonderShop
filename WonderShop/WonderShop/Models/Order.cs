using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public int? OrderNumber { get; set; }
        public string Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Customer Customer { get; set; }
    }
}