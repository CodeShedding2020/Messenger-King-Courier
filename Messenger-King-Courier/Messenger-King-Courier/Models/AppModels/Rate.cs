﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger_King_Courier.Models.AppModels
{
    public class Rate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vehicle_ID { get; set; }

        [Required(ErrorMessage = "Item length is required")]
        [DisplayName("Sevice cost")]
        public decimal Base_Cost { get; set; }

        [Required(ErrorMessage = "Cost per CM  is required")]
        [DisplayName("Cost per CM")]
        public int Rate_PerCM { get; set; }

        [Required(ErrorMessage = "Cost per KG is required")]
        [DisplayName("Cost per KG")]
        public int Rate_PerKG { get; set; }

        [Required(ErrorMessage = "Cost per KM is required")]
        [DisplayName("Cost per KM")]
        public int Rate_PerKM { get; set; }

      public virtual List<Quote> Quotes { get; set; }

    }
}