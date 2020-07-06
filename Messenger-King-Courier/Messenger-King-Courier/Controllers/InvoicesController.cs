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
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Bank).Include(i => i.Month).Include(i => i.Order);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.Bank_ID = new SelectList(db.Banks, "Bank_ID", "Bank_Account_Holder");
            ViewBag.Month_ID = new SelectList(db.Months, "Month_ID", "Month_Name");
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Order_ID");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Invoice_ID,Invoice_Date,Invoice_Amount,Invoice_DueDate,Invoice_AmountDue,Invoice_VAT,Order_ID,Month_ID,Bank_ID")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bank_ID = new SelectList(db.Banks, "Bank_ID", "Bank_Account_Holder", invoice.Bank_ID);
            ViewBag.Month_ID = new SelectList(db.Months, "Month_ID", "Month_Name", invoice.Month_ID);
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Order_ID", invoice.Order_ID);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bank_ID = new SelectList(db.Banks, "Bank_ID", "Bank_Account_Holder", invoice.Bank_ID);
            ViewBag.Month_ID = new SelectList(db.Months, "Month_ID", "Month_Name", invoice.Month_ID);
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Order_ID", invoice.Order_ID);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Invoice_ID,Invoice_Date,Invoice_Amount,Invoice_DueDate,Invoice_AmountDue,Invoice_VAT,Order_ID,Month_ID,Bank_ID")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bank_ID = new SelectList(db.Banks, "Bank_ID", "Bank_Account_Holder", invoice.Bank_ID);
            ViewBag.Month_ID = new SelectList(db.Months, "Month_ID", "Month_Name", invoice.Month_ID);
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Order_ID", invoice.Order_ID);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
