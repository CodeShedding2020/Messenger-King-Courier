using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Messenger_King_Courier.ViewModels
{
    public class InspectedVehicles
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VModelKey { get; set; }
        public string Vehicle_ID{ get; set; }
        [DisplayName("Date of Inspection")]
        public DateTime Inspection_Date { get; set; }
        public string InspectCat_Status { get; set; }
    }
}