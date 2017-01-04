using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderShop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public double? Discount { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}