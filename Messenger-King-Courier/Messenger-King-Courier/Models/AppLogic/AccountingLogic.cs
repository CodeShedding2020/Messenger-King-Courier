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

       public int GetQuoteId(string id) 
        
        {
            var clientCat = (from cl in ApplicationDb.Clients
                                       where cl.Client_ID == id
                             select cl.ClientCat_ID).SingleOrDefault();

                   var rateId = (from cl in ApplicationDb.Rates
                                       where cl.ClientCat_ID == clientCat
                                    select cl.Rate_ID).SingleOrDefault();
            return rateId;
        }

        public decimal GetQouteCost(float dist, double quant, double lent, double hght, double widt, double wght, int client_id)
        {
            decimal cost = 0;
            int clientCat = (from cl in ApplicationDb.Rates
                             where cl.Rate_ID== client_id
                             select cl.ClientCat_ID).SingleOrDefault();

            decimal cm = (from l in ApplicationDb.Rates
                          where l.ClientCat_ID == clientCat
                          select l.Rate_PerCM).SingleOrDefault();

            decimal kg = (from g in ApplicationDb.Rates
                          where g.ClientCat_ID == clientCat
                          select g.Rate_PerKG).SingleOrDefault();

            decimal km = (from k in ApplicationDb.Rates
                          where k.ClientCat_ID == clientCat
                          select k.Rate_PerKM).SingleOrDefault();

            cost = ((cm * (decimal)(lent + hght + wght + widt) + (kg * (decimal)wght)) * (decimal)quant) + (km * (decimal)dist);


            decimal basic = (from b in ApplicationDb.Rates
                             where b.ClientCat_ID == clientCat
                             select b.Base_Cost).SingleOrDefault();
            cost += basic;

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