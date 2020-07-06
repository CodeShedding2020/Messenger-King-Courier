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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Bookings).Include(o => o.Inspection).Include(o => o.OrderCategory);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
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

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.Book_ID = new SelectList(db.Bookings, "Book_ID", "Book_RecipientName");
            ViewBag.Inspection_ID = new SelectList(db.Inspections, "Inspection_ID", "Condition");
            ViewBag.OrderCat_ID = new SelectList(db.OrderCategories, "OrderCat_ID", "OrderCat_Status");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,Order_DateTime,Order_DeliveryDate,Book_ID,Inspection_ID,OrderCat_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_ID = new SelectList(db.Bookings, "Book_ID", "Book_RecipientName", order.Book_ID);
            ViewBag.Inspection_ID = new SelectList(db.Inspections, "Inspection_ID", "Condition", order.Inspection_ID);
            ViewBag.OrderCat_ID = new SelectList(db.OrderCategories, "OrderCat_ID", "OrderCat_Status", order.OrderCat_ID);
            return View(order);
        }

        // GET: Orders/Edit/5
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
            ViewBag.Book_ID = new SelectList(db.Bookings, "Book_ID", "Book_RecipientName", order.Book_ID);
            ViewBag.Inspection_ID = new SelectList(db.Inspections, "Inspection_ID", "Condition", order.Inspection_ID);
            ViewBag.OrderCat_ID = new SelectList(db.OrderCategories, "OrderCat_ID", "OrderCat_Status", order.OrderCat_ID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,Order_DateTime,Order_DeliveryDate,Book_ID,Inspection_ID,OrderCat_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_ID = new SelectList(db.Bookings, "Book_ID", "Book_RecipientName", order.Book_ID);
            ViewBag.Inspection_ID = new SelectList(db.Inspections, "Inspection_ID", "Condition", order.Inspection_ID);
            ViewBag.OrderCat_ID = new SelectList(db.OrderCategories, "OrderCat_ID", "OrderCat_Status", order.OrderCat_ID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
