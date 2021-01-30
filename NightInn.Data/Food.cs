using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NightInnV2.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        [Display(Name = "Meal Name")]
        public string FoodName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }
        public int FoodServingSize { get; set; }
        public Guid OwnerId { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
    }
}