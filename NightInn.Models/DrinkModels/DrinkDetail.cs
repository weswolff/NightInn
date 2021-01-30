using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Models.DrinkModels
{
    public class DrinkDetail
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public int ThemeId { get; set; }
        public Decimal DrinkAbv { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int DrinkServingSize { get; set; }
    }
}
