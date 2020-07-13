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
    public class InspectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inspections
        public ActionResult Index()
        {
            var inspections = db.Inspections.Include(i => i.InspectionCategory).Include(i => i.Vehicle);
            return View(inspections.ToList());
        }

        // GET: Inspections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspection inspection = db.Inspections.Find(id);
            if (inspection == null)
            {
                return HttpNotFound();
            }
            return View(inspection);
        }

        // GET: Inspections/Create
        public ActionResult Create()
        {
            ViewBag.InspectCat_ID = new SelectList(db.InspectionCategories, "InspectCat_ID", "InspectCat_Status");
            ViewBag.Vehicle_ID = new SelectList(db.Vehicles, "Vehicle_ID", "Vehicle_Make");
            return View();
        }

        // POST: Inspections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Inspection_ID,Condition,Inspection_Date,Vehicle_ID,InspectCat_ID")] Inspection inspection)
        {
            if (ModelState.IsValid)
            {
                inspection.Inspection_Date = DateTime.Now;
                db.Inspections.Add(inspection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InspectCat_ID = new SelectList(db.InspectionCategories, "InspectCat_ID", "InspectCat_Status", inspection.InspectCat_ID);
            ViewBag.Vehicle_ID = new SelectList(db.Vehicles, "Vehicle_ID", "Vehicle_Make", inspection.Vehicle_ID);
            return View(inspection);
        }

        // GET: Inspections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspection inspection = db.Inspections.Find(id);
            if (inspection == null)
            {
                return HttpNotFound();
            }
            ViewBag.InspectCat_ID = new SelectList(db.InspectionCategories, "InspectCat_ID", "InspectCat_Status", inspection.InspectCat_ID);
            ViewBag.Vehicle_ID = new SelectList(db.Vehicles, "Vehicle_ID", "Vehicle_Make", inspection.Vehicle_ID);
            return View(inspection);
        }

        // POST: Inspections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Inspection_ID,Condition,Inspection_Date,Vehicle_ID,InspectCat_ID")] Inspection inspection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InspectCat_ID = new SelectList(db.InspectionCategories, "InspectCat_ID", "InspectCat_Status", inspection.InspectCat_ID);
            ViewBag.Vehicle_ID = new SelectList(db.Vehicles, "Vehicle_ID", "Vehicle_Make", inspection.Vehicle_ID);
            return View(inspection);
        }

        // GET: Inspections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspection inspection = db.Inspections.Find(id);
            if (inspection == null)
            {
                return HttpNotFound();
            }
            return View(inspection);
        }

        // POST: Inspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inspection inspection = db.Inspections.Find(id);
            db.Inspections.Remove(inspection);
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
