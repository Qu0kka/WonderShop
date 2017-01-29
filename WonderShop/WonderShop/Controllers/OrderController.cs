using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WonderShop.Models;

namespace WonderShop.Controllers
{
    public class OrderController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer);
            return View(orders.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name");
            return View();
        }

        // POST: Order/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,OrderDate,ShipmentDate,OrderNumber,Status")] Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                // Запись ошибки в журнал (добавление имени переменной после DataException)
                ModelState.AddModelError("", "Unable to save changes. Tryagain, and if the problem persists see your system administrator.");
            }

            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", order.CustomerID);
            return View(order);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", order.CustomerID);
            return View(order);
        }

        // POST: Order/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,OrderDate,ShipmentDate,OrderNumber,Status")] Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                // Запись ошибки в журнал (добавление имени переменной после DataException)
                ModelState.AddModelError("", "Unable to save changes. Tryagain, and if the problem persists see your system administrator.");
            }

            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", order.CustomerID);
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(db.Orders.Find(id));

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Order order = db.Orders.Find(id);
            //if (order == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Order order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            catch (DataException)
            {
                // Запись ошибок в журнал (добавление имени переменной после DataException)
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary {
                { "id", id },
                { "saveChangesError", true }});
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
