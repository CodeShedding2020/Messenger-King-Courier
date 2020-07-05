using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driver.Models
{
    public class VehicleDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vehicle_ID_VIN { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Make should be between 2 to 20 Characters")]
        [Required(ErrorMessage = "The Make is required")]
        [DisplayName("Make")]
        public string Make { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Model should be between 2 to 20 Characters")]
        [Required(ErrorMessage = "The Model is required")]
        [DisplayName("Model")]
        public string Model { get; set; }

        [StringLength(4, MinimumLength = 4, ErrorMessage = "Please enter a valid Year")]
        [Required(ErrorMessage = "The Year is required")]
        [DisplayName("Year")]
        public string Year { get; set; }

        
        [Required(ErrorMessage = "The Registration number is required")]
        [DisplayName("Registration Number")]
        public string Reg_No { get; set; }

        [Required(ErrorMessage = "A colour is required")]
        [DisplayName("Colour")]
        public int Colour { get; set; }

    }
}
