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
       
        [DisplayName("Invoice date")]
        public DateTime Invoice_Date { get; set; }

        [DisplayName("Total amount")]
        public decimal Invoice_Amount { get; set; }

        [DisplayName("Due date")]
        public decimal Invoice_DueDate { get; set; }

        [DisplayName("Total amount due")]
        public decimal Invoice_AmountDue { get; set; }

        [DisplayName("VAT")]
        public decimal Invoice_VAT { get; set; }

        //[DisplayName("Order ID")]
        public int Order_ID { get; set; }
        public virtual Order Order { get; set; }
        public int Month_ID{ get; set; }
        public virtual Month  Month{ get; set; }

        public int Bank_ID { get; set; }
        public virtual Bank Bank { get; set; }

        public decimal CalcVat()
        {

            return Invoice_Amount * 0.15M;
        }


    }
}