using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Data
{
    public class Messenger_King_CourierContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Messenger_King_CourierContext() : base("name=Messenger_King_CourierContext")
        {
        }

        public System.Data.Entity.DbSet<Messenger_King_Courier.Models.Booking.BookingEntity> BookingEntities { get; set; }
    }
}
