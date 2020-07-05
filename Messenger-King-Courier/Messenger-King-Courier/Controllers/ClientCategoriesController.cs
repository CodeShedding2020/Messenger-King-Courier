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
    public class ClientCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClientCategories
        public ActionResult Index()
        {
            return View(db.ClientCategories.ToList());
        }

        // GET: ClientCategories/Details/5
        public ActionResult Details(string id)
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

        // GET: ClientCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientCat_ID,ClientCat_Type")] ClientCategory clientCategory)
        {
            if (ModelState.IsValid)
            {
                db.ClientCategories.Add(clientCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientCategory);
        }

        // GET: ClientCategories/Edit/5
        public ActionResult Edit(string id)
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

        // POST: ClientCategories/Edit/5
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

        // GET: ClientCategories/Delete/5
        public ActionResult Delete(string id)
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

        // POST: ClientCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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
