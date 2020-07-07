using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Models.AppModels
{
    public class OrderCategory
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Ordre  category ID")]
        public int OrderCat_ID { get; set; }

        [Required(ErrorMessage = "Order status is required")]
        [DisplayName("Order status")]
        public string OrderCat_Status { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}