using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Bank_ID { get; set; }

        [Required(ErrorMessage = "Account Holder is required")]
        [DisplayName("Account holder")]
        public string Bank_Account_Holder { get; set; }

        [Required(ErrorMessage = "Debit oder date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Delivery Date")]
        public DateTime Debit_Date { get; set; }

        public string Driver_IDNo { get; set; }
        public virtual Driver Driver { get; set; }

        public string CLient_IDNo { get; set; }
        public virtual Client Client { get; set; }

        public string BankCat_ID { get; set; }
        public virtual BankCategory BankCategory { get; set; }

        public string AccountCat_ID { get; set; }
        public virtual AccountCategory  AccountCategory{ get; set; }


    }
}