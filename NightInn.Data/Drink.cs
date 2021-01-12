using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NightInnV2.Models
{
    public class Drink
    {
        [Key]
        public int DrinkId { get; set; }
        [Required]
        public string DrinkName { get; set; }
        public Decimal DrinkAbv { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int DrinkServingSize { get; set; }

        [ForeignKey(nameof(Theme))]
        public int ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
    }
}