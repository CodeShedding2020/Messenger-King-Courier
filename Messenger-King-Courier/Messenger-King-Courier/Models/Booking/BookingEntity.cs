using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Models.Booking
{
    public class BookingEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Book_ID { get; set; }

        [Required(ErrorMessage = "Please select pickup date")]
        [DataType(DataType.Date)]
        [DisplayName("Pickup Date")]
        public DateTime Book_PickupDate { get; set; }
        [Required(ErrorMessage = "Please select delivery date")]
        [DataType(DataType.Date)]
        [DisplayName("Delivery Date")]
        public DateTime Book_DeliveryDate { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Recipient Name")]
        public string Book_RecipientName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Recipient Surname")]
        public string Book_RecipientSurname { get; set; }



        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please enter a valid phone number")]
        [Required(ErrorMessage = "The recipient's contact number is required")]
        [DisplayName("Recipient's Contact Number")]
        public string Book_RecipientNumber { get; set; }

        [StringLength(250, MinimumLength = 2, ErrorMessage = "The Delivery Note should be between 2 - 250 Characters")]
        [DisplayName("Delivery Note")]
        public string Book_DeliveryNote { get; set; }
       
        [DisplayName("Total Cost")]
        public double Book_TotalCost { get; set; }










    }
}