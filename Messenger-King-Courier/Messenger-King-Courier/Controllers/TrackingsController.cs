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
    public class TrackingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trackings
        public ActionResult Index()
        {
            var trackings = db.Trackings.Include(t => t.Order).Include(t => t.Tracking_Category);
            return View(trackings.ToList());
        }

        // GET: Trackings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracking tracking = db.Trackings.Find(id);
            if (tracking == null)
            {
                return HttpNotFound();
            }
            return View(tracking);
        }

        // GET: Trackings/Create
        public ActionResult Create()
        {
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Order_ID");
            ViewBag.TrackingCat_ID = new SelectList(db.TrackingCategories, "TrackingCat_ID", "TrackingCat_Status");
            return View();
        }

        // POST: Trackings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Track_ID,Track_Message,Order_ID,TrackingCat_ID")] Tracking tracking)
        {
            if (ModelState.IsValid)
            {
                db.Trackings.Add(tracking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Order_ID", tracking.Order_ID);
            ViewBag.TrackingCat_ID = new SelectList(db.TrackingCategories, "TrackingCat_ID", "TrackingCat_Status", tracking.TrackingCat_ID);
            return View(tracking);
        }

        // GET: Trackings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracking tracking = db.Trackings.Find(id);
            if (tracking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Order_ID", tracking.Order_ID);
            ViewBag.TrackingCat_ID = new SelectList(db.TrackingCategories, "TrackingCat_ID", "TrackingCat_Status", tracking.TrackingCat_ID);
            return View(tracking);
        }

        // POST: Trackings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Track_ID,Track_Message,Order_ID,TrackingCat_ID")] Tracking tracking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Order_ID", tracking.Order_ID);
            ViewBag.TrackingCat_ID = new SelectList(db.TrackingCategories, "TrackingCat_ID", "TrackingCat_Status", tracking.TrackingCat_ID);
            return View(tracking);
        }

        // GET: Trackings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracking tracking = db.Trackings.Find(id);
            if (tracking == null)
            {
                return HttpNotFound();
            }
            return View(tracking);
        }

        // POST: Trackings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tracking tracking = db.Trackings.Find(id);
            db.Trackings.Remove(tracking);
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
