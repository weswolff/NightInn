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
        public Guid OwnerId { get; set; }
        public virtual ICollection<Food> Foods { get; set; } = new HashSet<Food>();
        public virtual ICollection<Drink> Drinks { get; set; } = new HashSet<Drink>();
    }
}