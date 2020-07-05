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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vehicle_ID { get; set; }//(VIN)
        
        [Required(ErrorMessage = "Vehicle make is reqiured")]
        [DisplayName("Make")]
        public  string Vehicle_Make { get; set; }

        [Required(ErrorMessage = "Vehicle model is required")]
        [DisplayName("Model")]
        public string Vehicle_Model { get; set; }

        [Required(ErrorMessage = "Vehicle year is required")]
        [DisplayName("Year")]
        public DateTime Vehicle_Year { get; set; }

        [Required(ErrorMessage = "Vehicle registration number is required")]
        [DisplayName("Registration number")]
        public string Vehicle_RegNo { get; set; }

        [Required(ErrorMessage = "Vehicle colour is required")]
        [DisplayName("Colour")]
        public string Vehicle_Colour { get; set; }
        public int Driver_ID { get; set; }
        public virtual Driver Driver { get; set; }
       
    }
}