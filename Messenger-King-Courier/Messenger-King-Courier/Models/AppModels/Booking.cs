using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Book_ID { get; set; }

        [Required(ErrorMessage = "Pickup date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Pickup Date")]
        public DateTime Book_PickupDate { get; set; }

        [Required(ErrorMessage = "Delivery date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Delivery Date")]
        public DateTime Book_DeliveryDate { get; set; }

        [Required(ErrorMessage = " Recipient name is required")]
        [DisplayName("Recipient Name")]
        public string Book_RecipientName { get; set; }

        [Required(ErrorMessage = "Recipient surname is required")]
        [DisplayName("Recipient Surname")]
        public string Book_RecipientSurname { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Recipient contact number is required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                  ErrorMessage = "Entered Contact number format is not valid.")]
        public string Book_RecipientNumber { get; set; }

        [StringLength(250, MinimumLength = 2, ErrorMessage = "The Delivery Note should be between 2 - 250 Characters")]
        [DisplayName("Delivery Note")]
        public string Book_DeliveryNote { get; set; }
       
        [DisplayName("Total Cost")]
        public double Book_TotalCost { get; set; }

        public int Quote_ID { get; set; }
        public virtual Quote Quote { get; set; }
        
        public virtual List<Order> Order { get; set; }

    }
}
