using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class AccountCategory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Bank Category ID")]
        public int AccountCat_ID { get; set; }

        [Required(ErrorMessage = "Bank name is required")]
        [DisplayName("Bank name")]
        public string Account_Type { get; set; }

        public virtual List<Bank> Banks { get; set; }

    }
}