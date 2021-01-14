using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Models.DrinkModels
{
    public class DrinkListItem
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public int ThemeId { get; set; }
        public int DrinkServingSize { get; set; }
    }
}
