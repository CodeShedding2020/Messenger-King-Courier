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