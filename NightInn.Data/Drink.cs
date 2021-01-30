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
        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }
        public int DrinkServingSize { get; set; }
        public Guid OwnerId { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
    }
}