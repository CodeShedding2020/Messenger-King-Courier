using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Models.Invoice
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Invoice ID")]
        public int Invoice_ID { get; set; }

        [DisplayName("Invoice Date")]
        public DateTime Invoice_Date { get; set; }

        [DisplayName("Bill Amount")]
        public double Invoice_Amount { get; set; }

        [DisplayName("Due Date")]
        public DateTime Invoice_DueDate { get; set; }

        [DisplayName("Balance Due")]
        public DateTime Invoice_BalanceDue { get; set; }

        [DisplayName("VAT Amount")]
        public DateTime Invoice_VAT { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}