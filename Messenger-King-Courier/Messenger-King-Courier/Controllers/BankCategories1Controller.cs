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
    public class BankCategories1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BankCategories1
        public ActionResult Index()
        {
            return View(db.BankCategories.ToList());
        }

        // GET: BankCategories1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankCategory bankCategory = db.BankCategories.Find(id);
            if (bankCategory == null)
            {
                return HttpNotFound();
            }
            return View(bankCategory);
        }

        // GET: BankCategories1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankCategories1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankCat_ID,Bank_Name")] BankCategory bankCategory)
        {
            if (ModelState.IsValid)
            {
                bankCategory.Bank_Name = bankCategory.Bank_Name;
                db.BankCategories.Add(bankCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankCategory);
        }

        // GET: BankCategories1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankCategory bankCategory = db.BankCategories.Find(id);
            if (bankCategory == null)
            {
                return HttpNotFound();
            }
            return View(bankCategory);
        }

        // POST: BankCategories1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankCat_ID,Bank_Name")] BankCategory bankCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankCategory);
        }

        // GET: BankCategories1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankCategory bankCategory = db.BankCategories.Find(id);
            if (bankCategory == null)
            {
                return HttpNotFound();
            }
            return View(bankCategory);
        }

        // POST: BankCategories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankCategory bankCategory = db.BankCategories.Find(id);
            db.BankCategories.Remove(bankCategory);
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
