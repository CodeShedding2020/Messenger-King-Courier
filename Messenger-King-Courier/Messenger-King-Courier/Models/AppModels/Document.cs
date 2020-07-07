using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Document ID")]
        public int Documents_ID { get; set; }

        [DisplayName("ID Document")]
        public byte[] Document_ID { get; set; }

        [DisplayName("Proof of residence")]
        public byte[] Document_Residence{ get; set; }

        [DisplayName("Bank statement")]
        public byte[] Document_Statement { get; set; }


        public string Client_ID { get; set; }
        public virtual Client Client { get; set; }

        public string Driver_IDNo { get; set; }
        public virtual Driver Driver { get; set; }
       

    }
}