using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class ClientCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Client Category ID")]
        public string ClientCat_ID { get; set; }

        [Required(ErrorMessage = "Category type is required")]
        [DisplayName("Client Type")]
        public string ClientCat_Type { get; set; }

    }
}