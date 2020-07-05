using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class BankCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Bank Category ID")]
        public int BankCat_ID { get; set; }

        [Required(ErrorMessage = "Bank name is required")]
        [DisplayName("Bank name")]
        public string Bank_Name { get; set; }

        public virtual List<Bank> Banks { get; set; }

    }
}