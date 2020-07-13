using Messenger_King_Courier.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Models.AppLogic
{
    public class AccountingLogic
    {
        ApplicationDbContext ApplicationDb = new ApplicationDbContext();
       public decimal GetQouteCost(float dist, double quant,double lent, double hght,double widt,double wght)
        {
            decimal cost = 0;
            decimal cm = (from l in ApplicationDb.Rates
                          where l.Rate_ID == 1
                          select l.Rate_PerCM).SingleOrDefault();

            decimal kg = (from g in ApplicationDb.Rates
                          where g.Rate_ID == 1
                          select g.Rate_PerKG).SingleOrDefault();

            decimal km = (from k in ApplicationDb.Rates
                          where k.Rate_ID == 1
                          select k.Rate_PerKM).SingleOrDefault();

            cost = ((cm * (decimal)(lent + hght + wght) + (kg * (decimal)wght)) * (decimal)quant) * (decimal)dist;


            decimal basic = (from b in ApplicationDb.Rates
                          where b.Rate_ID == 1
                          select b.Base_Cost).SingleOrDefault();
            cost += cost * basic;

            return Convert.ToDecimal(cost);
        
        }
        
        public void QouteStatus(int? id, Quote app)
        {
           app = (from a in ApplicationDb.Quotes
                              where a.Quote_ID == id
                              select a).Single();
            app.Quote_Status = true;
            ApplicationDb.SaveChanges();

        }
    }
}