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
    public class ClientCategories1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClientCategories1
        public ActionResult Index()
        {
            return View(db.ClientCategories.ToList());
        }

        // GET: ClientCategories1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCategory clientCategory = db.ClientCategories.Find(id);
            if (clientCategory == null)
            {
                return HttpNotFound();
            }
            return View(clientCategory);
        }

        // GET: ClientCategories1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientCategories1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientCat_ID,ClientCat_Type")] ClientCategory clientCategory)
        {
            if (ModelState.IsValid)
            {
                clientCategory.ClientCat_Type = clientCategory.ClientCat_Type;
                db.ClientCategories.Add(clientCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientCategory);
        }

        // GET: ClientCategories1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCategory clientCategory = db.ClientCategories.Find(id);
            if (clientCategory == null)
            {
                return HttpNotFound();
            }
            return View(clientCategory);
        }

        // POST: ClientCategories1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientCat_ID,ClientCat_Type")] ClientCategory clientCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientCategory);
        }

        // GET: ClientCategories1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCategory clientCategory = db.ClientCategories.Find(id);
            if (clientCategory == null)
            {
                return HttpNotFound();
            }
            return View(clientCategory);
        }

        // POST: ClientCategories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientCategory clientCategory = db.ClientCategories.Find(id);
            db.ClientCategories.Remove(clientCategory);
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
