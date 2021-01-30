using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NightInn.Models.DrinkModels
{
    public class DrinkCreate
    {
        public int DrinkId { get; set; }
        [Required]
        public string DrinkName { get; set; }
        public int ThemeId { get; set; }
        public Decimal DrinkAbv { get; set; }
        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }
        public int DrinkServingSize { get; set; }
        public IEnumerable<SelectListItem> Themes { get; set; }
        public MultiSelectList ThemeList { get; set; }
        public int[] SelectedThemeIds { get; set; }

    }
}
