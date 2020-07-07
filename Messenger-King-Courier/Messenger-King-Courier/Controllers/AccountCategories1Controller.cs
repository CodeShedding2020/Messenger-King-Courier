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
    public class AccountCategories1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccountCategories1
        public ActionResult Index()
        {
            return View(db.AccountCategories.ToList());
        }

        // GET: AccountCategories1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountCategory accountCategory = db.AccountCategories.Find(id);
            if (accountCategory == null)
            {
                return HttpNotFound();
            }
            return View(accountCategory);
        }

        // GET: AccountCategories1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountCategories1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountCat_ID,Account_Type")] AccountCategory accountCategory)
        {
            if (ModelState.IsValid)
            {
                accountCategory.Account_Type = accountCategory.Account_Type;
                db.AccountCategories.Add(accountCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountCategory);
        }

        // GET: AccountCategories1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountCategory accountCategory = db.AccountCategories.Find(id);
            if (accountCategory == null)
            {
                return HttpNotFound();
            }
            return View(accountCategory);
        }

        // POST: AccountCategories1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountCat_ID,Account_Type")] AccountCategory accountCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountCategory);
        }

        // GET: AccountCategories1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountCategory accountCategory = db.AccountCategories.Find(id);
            if (accountCategory == null)
            {
                return HttpNotFound();
            }
            return View(accountCategory);
        }

        // POST: AccountCategories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountCategory accountCategory = db.AccountCategories.Find(id);
            db.AccountCategories.Remove(accountCategory);
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
