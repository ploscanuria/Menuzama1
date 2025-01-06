using System.ComponentModel.DataAnnotations;

namespace Menuzama1.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public ICollection<MenuItem>? MenuItems { get; set; }
    }
}
