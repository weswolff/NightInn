using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightInnV2.Models
{
    public class Theme
    {
        [Key]
        public int ThemeId { get; set; }
        [Required]
        public string ThemeName { get; set; }
    }
}