using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Month
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Month number")]
        public int Month_ID { get; set; }

        [Required(ErrorMessage = "Month name is required")]
        [DisplayName("Month")]
        public string Month_Name { get; set; }
        
        public virtual List<Invoice> Invoices { get; set;}
    }
}