using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity;
using System.Web.Mvc;
using System;
using Newtonsoft.Json;

namespace Messenger_King_Courier.Models.AppModels
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
        public decimal Invoice_Amount { get; set; }

        [DisplayName("Due Date")]
        public DateTime Invoice_DueDate { get; set; }

        [DisplayName("Balance Due")]
        public DateTime Invoice_BalanceDue { get; set; }

        [DisplayName("VAT Amount")]
        public DateTime Invoice_VAT { get; set; }

        public int Order_ID { get; set; }
        public virtual Order Order { get; set; }

    }
}