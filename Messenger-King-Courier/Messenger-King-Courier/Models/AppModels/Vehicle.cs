using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Vehicle Identification Number is reqiured")]
        [DisplayName("VIN")]
        public string Vehicle_ID { get; set; }//(VIN)
        
        [Required(ErrorMessage = "Vehicle make is reqiured")]
        [DisplayName("Make")]
        public  string Vehicle_Make { get; set; }

        [Required(ErrorMessage = "Vehicle model is required")]
        [DisplayName("Model")]
        public string Vehicle_Model { get; set; }

        [Required(ErrorMessage = "Vehicle year is required")]
        [DisplayName("Year")]
        public DateTime Vehicle_Year { get; set; }

        [Required(ErrorMessage = "Number plate is required")]
        [DisplayName("Number plate")]
        public string Vehicle_RegNo { get; set; }

        [Required(ErrorMessage = "Vehicle colour is required")]
        [DisplayName("Colour")]
        public string Vehicle_Colour { get; set; }
        public string Driver_IDNo { get; set; }
        public virtual Driver Driver { get; set; }
       
        public virtual List<Inspection> Inspections { get; set; }
    }
}