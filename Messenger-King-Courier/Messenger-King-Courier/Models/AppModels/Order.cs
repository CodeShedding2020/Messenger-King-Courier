﻿using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity;
using System.Web.Mvc;
using System;
using Messenger_King_Courier.Models.AppModels;
using System.Collections.Generic;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Order_DateTime { get; set; }

        public int Book_ID { get; set; }
        public virtual Booking Bookings { get; set; }

        public int Inspection_ID { get; set; }
        public virtual Inspection Inspection { get; set; }

        public int OrderCat_ID { get; set; }
        public virtual OrderCategory OrderCategory { get; set; }

        public virtual List<Invoice> Invoices { get; set; }

    }
}