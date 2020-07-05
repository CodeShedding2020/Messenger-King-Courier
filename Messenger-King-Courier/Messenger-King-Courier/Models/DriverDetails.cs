using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driver.Models
{
    public class DriverDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Driver_ID { get; set; }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "Name should be between 2 to 40 Characters")]
        [Required(ErrorMessage = "The Name of the Driver is required")]
        [DisplayName("Driver Name")]
        public string Driver_Name { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname should be between 2 to 50 Characters")]
        [Required(ErrorMessage = "The Surname of the Driver is required")]
        [DisplayName("Driver Surname")]
        public string Driver_Surname { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "Please enter a valid SA Id Number")]
        [Required(ErrorMessage = "The Id Number of the Driver is required")]
        [DisplayName("ID number")]
        public string Driver_IDNO { get; set; }

        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please enter a valid phone number")]
        [Required(ErrorMessage = "The Cell number of the Driver is required")]
        [DisplayName("Cell Number")]
        public string Driver_Cell { get; set; }

        [Required(ErrorMessage = "An Address is required")]
        [DisplayName("Address")]
        public int Driver_Address { get; set; }                                                     

    }
}