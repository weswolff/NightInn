using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Models.FoodModels
{
    public class FoodEdit
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int ThemeId { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int FoodServingSize { get; set; }
    }
}
