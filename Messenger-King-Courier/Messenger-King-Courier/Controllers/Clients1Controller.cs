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
    public class Clients1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients1
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.ClientCategory);
            return View(clients.ToList());
        }

        // GET: Clients1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients1/Create
        public ActionResult Create()
        {
            ViewBag.ClientCat_ID = new SelectList(db.ClientCategories, "ClientCat_ID", "ClientCat_Type");
            return View();
        }

        // POST: Clients1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLient_IDNo,Client_Name,Client_Surname,Client_Cellnumber,Client_Address,Client_Email,Client_Tellnum,ClientCat_ID")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.Client_Name = client.Client_Name;
                client.Client_Surname = client.Client_Surname;
                client.Client_Cellnumber = client.Client_Cellnumber;
                client.Client_Address = client.Client_Address;
                client.Client_Email = client.Client_Email;
                client.Client_Tellnum = client.Client_Tellnum;
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientCat_ID = new SelectList(db.ClientCategories, "ClientCat_ID", "ClientCat_Type", client.ClientCat_ID);
            return View(client);
        }

        // GET: Clients1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientCat_ID = new SelectList(db.ClientCategories, "ClientCat_ID", "ClientCat_Type", client.ClientCat_ID);
            return View(client);
        }

        // POST: Clients1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLient_IDNo,Client_Name,Client_Surname,Client_Cellnumber,Client_Address,Client_Email,Client_Tellnum,ClientCat_ID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientCat_ID = new SelectList(db.ClientCategories, "ClientCat_ID", "ClientCat_Type", client.ClientCat_ID);
            return View(client);
        }

        // GET: Clients1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
