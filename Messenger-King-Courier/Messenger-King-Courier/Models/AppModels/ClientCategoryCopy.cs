using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Messenger_King_Courier.Models.AppModels
{
    public class ClientCategoryCopy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Client Category ID")]
        public int ClientCategoryCopy_ID { get; set; }

        [Required(ErrorMessage = "Category type is required")]
        [DisplayName("Client Type")]
        public string ClientCategoryCopy_Type { get; set; }
    }
}