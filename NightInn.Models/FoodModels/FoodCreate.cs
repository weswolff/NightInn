﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Models
{
    public class FoodCreate
    {
        public int FoodID { get; set; }
        [Required]
        [Display(Name = "Meal Name")]
        public string FoodName { get; set; }
        [Required]
        public int ThemeId { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Display(Name = "Serving Size")]
        public int FoodServingSize { get; set; }
    }
}