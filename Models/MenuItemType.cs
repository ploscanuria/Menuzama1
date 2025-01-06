using System.ComponentModel.DataAnnotations;

namespace Menuzama1.Models
{
    public class MenuItemType
    {
        public int ID { get; set; }
        [Display(Name = "Type Name")]
        public string Name { get; set; } // Ex. Starter, Main Course, etc.

        // Relație 1:N cu MenuItem
        public ICollection<MenuItem>? MenuItems { get; set; }
    }
}
