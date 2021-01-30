using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Models.ThemeModels
{
    public class ThemeCreate
    {
        public int ThemeId { get; set; }
        [Required]
        public string ThemeName { get; set; }
    }
}
