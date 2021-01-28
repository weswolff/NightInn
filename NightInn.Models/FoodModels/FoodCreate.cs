using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NightInn.Models
{
    public class FoodCreate
    {
        public int FoodId { get; set; }
        [Required]
        [Display(Name = "Meal Name")]
        public string FoodName { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Display(Name = "Serving Size")]
        public int FoodServingSize { get; set; }
        public IEnumerable<SelectListItem> Themes { get; set; }
        public MultiSelectList ThemeList { get; set; }
        public int[] SelectedThemeIds { get; set; }
    }
}
