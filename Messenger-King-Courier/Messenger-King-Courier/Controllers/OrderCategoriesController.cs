using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Messenger_King_Courier.Models;
using Messenger_King_Courier.Models.AppModels;

namespace Messenger_King_Courier.Controllers
{
    public class OrderCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderCategories
        public ActionResult Index()
        {
            return View(db.OrderCategories.ToList());
        }

        // GET: OrderCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderCategory orderCategory = db.OrderCategories.Find(id);
            if (orderCategory == null)
            {
                return HttpNotFound();
            }
            return View(orderCategory);
        }

        // GET: OrderCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderCat_ID,OrderCat_Status")] OrderCategory orderCategory)
        {
            if (ModelState.IsValid)
            {
                db.OrderCategories.Add(orderCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderCategory);
        }

        // GET: OrderCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderCategory orderCategory = db.OrderCategories.Find(id);
            if (orderCategory == null)
            {
                return HttpNotFound();
            }
            return View(orderCategory);
        }

        // POST: OrderCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderCat_ID,OrderCat_Status")] OrderCategory orderCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderCategory);
        }

        // GET: OrderCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderCategory orderCategory = db.OrderCategories.Find(id);
            if (orderCategory == null)
            {
                return HttpNotFound();
            }
            return View(orderCategory);
        }

        // POST: OrderCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderCategory orderCategory = db.OrderCategories.Find(id);
            db.OrderCategories.Remove(orderCategory);
            db.SaveChanges();
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
