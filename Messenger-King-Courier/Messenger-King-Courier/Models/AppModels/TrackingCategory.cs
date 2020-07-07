using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class TrackingCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Tracking category ID")]
        public int TrackingCat_ID { get; set; }

        [Required(ErrorMessage ="Tracking status is required")]
        [DisplayName("Tracking status")]
        public string TrackingCat_Status { get; set; }

        public virtual List<Tracking> Trackings { get; set; }
    }
}