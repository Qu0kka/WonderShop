using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderShop.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}