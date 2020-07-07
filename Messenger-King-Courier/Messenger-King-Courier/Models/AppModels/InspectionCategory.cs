using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Models.AppModels
{
    public class InspectionCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InspectCat_ID { get; set; }

        [Required(ErrorMessage = "Inspection status is required")]
        [DisplayName("Inspection status")]
        public string InspectCat_Status { get; set; }
        public virtual List<Inspection> Inspections { get; set; }
    }
}       
