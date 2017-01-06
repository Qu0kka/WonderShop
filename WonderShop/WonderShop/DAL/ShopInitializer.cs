using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WonderShop.Models;

namespace WonderShop.DAL
{
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Galileo Galilei", Code = "1502-1564", Address = "Italy Pisa", Discount = 0 },
                new Customer {Name = "Leonardo di ser Piero da Vinci", Code = "1504-1452", Address = "Florentia Vinci", Discount = 5 },
                new Customer {Name = "Michelangelo di Lodovico di Leonardo di Buonarroti Simoni", Code = "0603-1475", Address = "Italy Rome", Discount = 10 }
            };
            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order {CustomerID = 1, OrderDate = DateTime.Parse("2017-01-01"), ShipmentDate = DateTime.Parse("2017-02-02"), OrderNumber = 0001, Status = "NEW" },
                new Order {CustomerID = 2, OrderDate = DateTime.Parse("2016-12-31"), ShipmentDate = DateTime.Parse("2017-01-01"), OrderNumber = 0002, Status = "InProcess" },
                new Order {CustomerID = 3, OrderDate = DateTime.Parse("2017-01-02"), ShipmentDate = DateTime.Parse("2017-02-01"), OrderNumber = 0003, Status = "DONE" }
            };
            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();

            var orderItems = new List<OrderItem>
            {
                new OrderItem {OrderID = 1, ItemID = 1, ItemCount = 3, ItemPrice = 1000 },
                new OrderItem {OrderID = 1, ItemID = 2, ItemCount = 1, ItemPrice = 1500 },
                new OrderItem {OrderID = 2, ItemID = 1, ItemCount = 2, ItemPrice = 1000 },
                new OrderItem {OrderID = 2, ItemID = 2, ItemCount = 5, ItemPrice = 1500 },
                new OrderItem {OrderID = 2, ItemID = 3, ItemCount = 1, ItemPrice = 2000 },
                new OrderItem {OrderID = 3, ItemID = 3, ItemCount = 7, ItemPrice = 2000 }
            };
            orderItems.ForEach(s => context.OrderItems.Add(s));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item {Code = "00-0000-AA00", Name = "Happiness", Price = 1000, Category = "Moral" },
                new Item {Code = "00-0000-AA01", Name = "Sincerity", Price = 1500, Category = "Moral" },
                new Item {Code = "00-0000-AA02", Name = "Wisdom", Price = 2000, Category = "Moral" }
            };
            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();
        }
    }
}