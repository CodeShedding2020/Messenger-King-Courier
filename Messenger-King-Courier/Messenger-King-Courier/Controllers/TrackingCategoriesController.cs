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
    public class TrackingCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrackingCategories
        public ActionResult Index()
        {
            return View(db.TrackingCategories.ToList());
        }

        // GET: TrackingCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackingCategory trackingCategory = db.TrackingCategories.Find(id);
            if (trackingCategory == null)
            {
                return HttpNotFound();
            }
            return View(trackingCategory);
        }

        // GET: TrackingCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackingCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackingCat_ID,TrackingCat_Status")] TrackingCategory trackingCategory)
        {
            if (ModelState.IsValid)
            {
                db.TrackingCategories.Add(trackingCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trackingCategory);
        }

        // GET: TrackingCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackingCategory trackingCategory = db.TrackingCategories.Find(id);
            if (trackingCategory == null)
            {
                return HttpNotFound();
            }
            return View(trackingCategory);
        }

        // POST: TrackingCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackingCat_ID,TrackingCat_Status")] TrackingCategory trackingCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackingCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trackingCategory);
        }

        // GET: TrackingCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackingCategory trackingCategory = db.TrackingCategories.Find(id);
            if (trackingCategory == null)
            {
                return HttpNotFound();
            }
            return View(trackingCategory);
        }

        // POST: TrackingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrackingCategory trackingCategory = db.TrackingCategories.Find(id);
            db.TrackingCategories.Remove(trackingCategory);
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
