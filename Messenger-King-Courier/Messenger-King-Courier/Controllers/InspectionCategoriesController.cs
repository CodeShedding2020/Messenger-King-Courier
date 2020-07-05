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
    public class InspectionCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InspectionCategories
        public ActionResult Index()
        {
            return View(db.InspectionCategories.ToList());
        }

        // GET: InspectionCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionCategory inspectionCategory = db.InspectionCategories.Find(id);
            if (inspectionCategory == null)
            {
                return HttpNotFound();
            }
            return View(inspectionCategory);
        }

        // GET: InspectionCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InspectionCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InspectCat_ID,InspectCat_Status")] InspectionCategory inspectionCategory)
        {
            if (ModelState.IsValid)
            {
                db.InspectionCategories.Add(inspectionCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inspectionCategory);
        }

        // GET: InspectionCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionCategory inspectionCategory = db.InspectionCategories.Find(id);
            if (inspectionCategory == null)
            {
                return HttpNotFound();
            }
            return View(inspectionCategory);
        }

        // POST: InspectionCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InspectCat_ID,InspectCat_Status")] InspectionCategory inspectionCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inspectionCategory);
        }

        // GET: InspectionCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionCategory inspectionCategory = db.InspectionCategories.Find(id);
            if (inspectionCategory == null)
            {
                return HttpNotFound();
            }
            return View(inspectionCategory);
        }

        // POST: InspectionCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InspectionCategory inspectionCategory = db.InspectionCategories.Find(id);
            db.InspectionCategories.Remove(inspectionCategory);
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
