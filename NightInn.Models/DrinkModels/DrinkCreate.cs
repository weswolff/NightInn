using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Models.DrinkModels
{
    public class DrinkCreate
    {
        public int DrinkId { get; set; }
        [Required]
        public string DrinkName { get; set; }
        [Required]
        public int ThemeId { get; set; }
        public Decimal DrinkAbv { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int DrinkServingSize { get; set; }

    }
}
