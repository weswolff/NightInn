using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Models.FoodModels
{
    public class FoodListItem
    {
        public int FoodId { get; set; }
        [Display(Name = "Meal Name")]
        public string FoodName { get; set; }
        public string ThemeId { get; set; }
        public string Theme { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        [Display(Name = "Serving Size")]
        public int FoodServingSize { get; set; }
    }
}
