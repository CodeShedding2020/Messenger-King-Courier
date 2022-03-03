using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Messenger_King_Courier.Models;
using Messenger_King_Courier.Models.AppLogic;
using Messenger_King_Courier.Models.AppModels;
using Microsoft.AspNet.Identity;

namespace Messenger_King_Courier.Controllers
{
    [Authorize]
    public class QuotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quotes
        public ActionResult Index()
        {
            var quotes = db.Quotes.Include(q => q.Client).Include(q => q.Rate);
            return View(quotes.ToList());
        }

        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            var uid = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
          
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        /// <summary>
        /// I'm not sure what to do with the 
        /// below method but i have this idea in my head :) hope it works once implemented
        /// </summary>
        /// <returns></returns>

        //public ActionResult ConfirmQuote(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Quote quote = db.Quotes.Find(id);
        //    AccountingLogic accountingLogic = new AccountingLogic();
        //    accountingLogic.QouteStatus(id, quote);
        //    if (quote == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_IDNo", quote.Client_ID);
        //    ViewBag.Rate_ID = new SelectList(db.Rates, "Rate_ID", "Rate_ID", quote.Rate_ID);
        //    return RedirectToAction("Create", "", new { id = quote.Quote_ID });
            
        //}

        // GET: Quotes/Create
        public ActionResult Create()
        {
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_IDNo");
            ViewBag.Rate_ID = new SelectList(db.Rates, "Rate_ID", "Rate_ID");
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Quote_ID,Quote_Date,Quote_PickupAddress,Quote_DeliveryAddress,Quote_Distance,Quote_Description,Quote_Cost,Item_Quantity,Quote_length,Quote_Height,Quote_Width,Quote_Weight,Client_ID,Rate_ID")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client();
                if (client.ClientCategory.ClientCat_Type != null)
                {
                    AccountingLogic accountingLogic = new AccountingLogic();

                    var uid = User.Identity.GetUserId();
                    quote.Client_ID = uid;
                    quote.Rate_ID = accountingLogic.GetQuoteId(quote.Client_ID);
                    quote.Quote_Date = System.DateTime.Now;
                    quote.Quote_Distance = 00.00f;///Reserved for google  maps API
                    quote.Quote_Cost = accountingLogic.GetQouteCost(quote.Quote_Distance, quote.Item_Quantity, quote.Quote_length, quote.Quote_Height, quote.Quote_Width, quote.Quote_Weight, quote.Rate_ID);
                    db.Quotes.Add(quote);
                    db.SaveChanges();

                    return RedirectToAction("Details", "Quotes", new { id = quote.Quote_ID });
                }
            }



            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_IDNo", quote.Client_ID);
            ViewBag.Rate_ID = new SelectList(db.Rates, "Rate_ID", "Rate_ID", quote.Rate_ID);
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_IDNo", quote.Client_ID);
            ViewBag.Rate_ID = new SelectList(db.Rates, "Rate_ID", "Rate_ID", quote.Rate_ID);
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Quote_ID,Quote_Date,Quote_PickupAddress,Quote_DeliveryAddress,Quote_Distance,Quote_Description,Quote_Cost,Item_Quantity,Quote_length,Quote_Height,Quote_Width,Quote_Weight,Client_ID,Rate_ID")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_IDNo", quote.Client_ID);
            ViewBag.Rate_ID = new SelectList(db.Rates, "Rate_ID", "Rate_ID", quote.Rate_ID);
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
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
