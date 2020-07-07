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
    public class Banks1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Banks1
        public ActionResult Index()
        {
            var banks = db.Banks.Include(b => b.AccountCategory).Include(b => b.BankCategory).Include(b => b.Client).Include(b => b.Driver);
            return View(banks.ToList());
        }

        // GET: Banks1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // GET: Banks1/Create
        public ActionResult Create()
        {
            ViewBag.AccountCat_ID = new SelectList(db.AccountCategories, "AccountCat_ID", "Account_Type");
            ViewBag.BankCat_ID = new SelectList(db.BankCategories, "BankCat_ID", "Bank_Name");
            ViewBag.CLient_IDNo = new SelectList(db.Clients, "CLient_IDNo", "Client_Name");
            ViewBag.Driver_IDNo = new SelectList(db.Drivers, "Driver_IDNo", "Driver_Name");
            return View();
        }

        // POST: Banks1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bank_ID,Bank_Account_Holder,Bank_Account_Number,Debit_Date,Driver_IDNo,CLient_IDNo,BankCat_ID,AccountCat_ID")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                bank.Bank_Account_Holder = bank.Bank_Account_Holder;
                bank.Bank_Account_Number = bank.Bank_Account_Number;
                bank.Debit_Date = bank.Debit_Date;
                db.Banks.Add(bank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountCat_ID = new SelectList(db.AccountCategories, "AccountCat_ID", "Account_Type", bank.AccountCat_ID);
            ViewBag.BankCat_ID = new SelectList(db.BankCategories, "BankCat_ID", "Bank_Name", bank.BankCat_ID);
            ViewBag.CLient_IDNo = new SelectList(db.Clients, "CLient_IDNo", "Client_Name", bank.CLient_IDNo);
            ViewBag.Driver_IDNo = new SelectList(db.Drivers, "Driver_IDNo", "Driver_Name", bank.Driver_IDNo);
            return View(bank);
        }

        // GET: Banks1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountCat_ID = new SelectList(db.AccountCategories, "AccountCat_ID", "Account_Type", bank.AccountCat_ID);
            ViewBag.BankCat_ID = new SelectList(db.BankCategories, "BankCat_ID", "Bank_Name", bank.BankCat_ID);
            ViewBag.CLient_IDNo = new SelectList(db.Clients, "CLient_IDNo", "Client_Name", bank.CLient_IDNo);
            ViewBag.Driver_IDNo = new SelectList(db.Drivers, "Driver_IDNo", "Driver_Name", bank.Driver_IDNo);
            return View(bank);
        }

        // POST: Banks1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bank_ID,Bank_Account_Holder,Bank_Account_Number,Debit_Date,Driver_IDNo,CLient_IDNo,BankCat_ID,AccountCat_ID")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountCat_ID = new SelectList(db.AccountCategories, "AccountCat_ID", "Account_Type", bank.AccountCat_ID);
            ViewBag.BankCat_ID = new SelectList(db.BankCategories, "BankCat_ID", "Bank_Name", bank.BankCat_ID);
            ViewBag.CLient_IDNo = new SelectList(db.Clients, "CLient_IDNo", "Client_Name", bank.CLient_IDNo);
            ViewBag.Driver_IDNo = new SelectList(db.Drivers, "Driver_IDNo", "Driver_Name", bank.Driver_IDNo);
            return View(bank);
        }

        // GET: Banks1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Banks1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank bank = db.Banks.Find(id);
            db.Banks.Remove(bank);
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
