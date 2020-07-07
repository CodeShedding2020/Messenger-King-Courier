using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Quote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Quote ID")]
        public int Quote_ID { get; set; }

        [DisplayName("Quote Date")]
        public DateTime Quote_Date { get; set; }

        [Required(ErrorMessage = "Pickup address is required")]
        [DisplayName("Pickup address")]
        public string Quote_PickupAddress { get; set; }

        [Required(ErrorMessage = "Delivery address is required")]
        [DisplayName("Delivery address")]
        public string Quote_DeliveryAddress { get; set; }

        [DisplayName("Distance")]
        public float Quote_Distance { get; set; }

        [Required(ErrorMessage = "Item description is required")]
        [DisplayName("Item description")]
        public string Quote_Description { get; set; }

        [DisplayName("Total cost")]
        public decimal Quote_Cost { get; set; }

        [Required(ErrorMessage = "Item quantity is required")]
        [DisplayName("Item quantity")]
        public double Item_Quantity { get; set; }


        [Required(ErrorMessage = "Item length is required")]
        [DisplayName("Item length")]
        public double Quote_length { get; set; }


        [Required(ErrorMessage = "Item height is required")]
        [DisplayName("Item height")]
        public double Quote_Height { get; set; }



        [Required(ErrorMessage = "Item width is required")]
        [DisplayName("Item width")]
        public double Quote_Width { get; set; }
        


        [Required(ErrorMessage = "Item weight is required")]
        [DisplayName("Item weight")]
        public double Quote_Weight { get; set; }


        public string Client_ID { get; set; }
        public virtual Client Client { get; set; }

        public int Rate_ID { get; set; }
        public virtual Rate Rate { get; set; }
    }
}