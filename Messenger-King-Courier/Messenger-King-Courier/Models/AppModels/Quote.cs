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

        [ScaffoldColumn(false)]
        [DisplayName("Quote Date")]
        public DateTime Quote_Date { get; set; }

        [Required(ErrorMessage = "Pickup address is required")]
        [DisplayName("Pickup address")]
        public string Quote_PickupAddress { get; set; }

        [Required(ErrorMessage = "Delivery address is required")]
        [DisplayName("Delivery address")]
        public string Quote_DeliveryAddress { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Distance")]
        public float Quote_Distance { get; set; }

        [Required(ErrorMessage = "Item description is required")]
        [DisplayName("Item description")]
        [DataType(DataType.MultilineText)]
        public string Quote_Description { get; set; }

        [ScaffoldColumn(false)]
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
        [DisplayName("Quote status")]
        public bool Quote_Status { get; set; }

        [DisplayName("Client type")]
        public int ClientCategoryCopy_ID { get; set; }
        public virtual ClientCategoryCopy ClientCategoryCopy { get; set; }

        [ScaffoldColumn(false)]
        public int Rate_ID { get; set; }
        public virtual Rate Rate { get; set; }



        ApplicationDbContext db = new ApplicationDbContext();

        public int GetQuoteId()
        {

            var clientCatCopy = (from cl in db.ClientCategoryCopies
                                 where cl.ClientCategoryCopy_ID == ClientCategoryCopy_ID
                                 select cl.ClientCategoryCopy_Type).SingleOrDefault();

            var clientcatId = (from cl in db.ClientCategories
                               where cl.ClientCat_Type == clientCatCopy
                               select cl.ClientCat_ID).SingleOrDefault();


            var rateId = (from cl in db.Rates
                          where cl.Rate_ID == clientcatId
                          select cl.ClientCat_ID).SingleOrDefault();

            return rateId;
        }

        public decimal GetQouteCost()
        {
            decimal cost = 0;

            decimal cm = (from l in db.Rates
                          where l.ClientCat_ID == Rate_ID
                          select l.Rate_PerCM).SingleOrDefault();

            decimal kg = (from g in db.Rates
                          where g.ClientCat_ID == Rate_ID
                          select g.Rate_PerKG).SingleOrDefault();

            decimal km = (from k in db.Rates
                          where k.ClientCat_ID == Rate_ID
                          select k.Rate_PerKM).SingleOrDefault();

            cost = ((cm * (decimal)(Quote_length + Quote_Height + Quote_Width) + (kg * (decimal)Quote_Width)) * (decimal)Item_Quantity) + (km * (decimal)Quote_Distance);


            decimal basic = (from b in db.Rates
                             where b.ClientCat_ID == Rate_ID
                             select b.Base_Cost).SingleOrDefault();
            cost += basic;

            return Convert.ToDecimal(cost);

        }
    }
}
