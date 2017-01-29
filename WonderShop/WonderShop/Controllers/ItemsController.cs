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
    public class ItemsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Items
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Code,Name,Price,Category")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Items.Add(item);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                // Запись ошибки в журнал (добавление имени переменной после DataException)
                ModelState.AddModelError("", "Unable to save changes. Tryagain, and if the problem persists see your system administrator.");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Code,Name,Price,Category")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                // Запись ошибки в журнал (добавление имени переменной после DataException)
                ModelState.AddModelError("", "Unable to save changes. Tryagain, and if the problem persists see your system administrator.");
            }

            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(db.Items.Find(id));

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Item item = db.Items.Find(id);
            //if (item == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Item item = db.Items.Find(id);
                db.Items.Remove(item);
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
