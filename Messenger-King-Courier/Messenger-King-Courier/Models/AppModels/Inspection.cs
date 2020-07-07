using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Inspection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Inspection ID")]
        public int Inspection_ID { get; set; }

        [DisplayName("Vehicle condition")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Inspection date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Inspection date")]
        public DateTime Inspection_Date { get; set; }

        public string Vehicle_ID { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public int InspectCat_ID { get; set; }
        public virtual InspectionCategory InspectionCategory   { get; set; }
       

    }
}