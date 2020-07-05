using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Messenger_King_Courier.Models.AppModels
{
    public class Tracking
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Tracking number")]
        public int Track_ID { get; set; }

        [DisplayName("Tracking Message")]
        public int Track_Message { get; set; }
   
        public int TrackingCat_ID { get; set; }
        public virtual TrackingCategory TrackingCategory { get; set; }

        public int Order_ID { get; set; }
        public virtual Order Order { get; set; }

        public int TrackingStat_ID { get; set; }
        public virtual TrackingCategory Tracking_Category { get; set;}

    }
}