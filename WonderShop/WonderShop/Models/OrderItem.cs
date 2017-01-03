using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderShop.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int ItemCount { get; set; }
        public double ItemPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}