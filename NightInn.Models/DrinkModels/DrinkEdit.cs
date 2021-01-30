using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Models.DrinkModels
{
    public class DrinkEdit
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public int ThemeId { get; set; }
        public Decimal DrinkAbv { get; set; }
        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }
        public int DrinkServingSize { get; set; }
    }
}
