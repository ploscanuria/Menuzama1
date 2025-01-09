using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Menuzama1.Models
{
    public class MenuItem
    {

       
        
            public int Id { get; set; }

            [Required(ErrorMessage = "The Name field is required.")]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "The Name must be between 1 and 100 characters long.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "The Description field is required.")]
            [StringLength(500, ErrorMessage = "The Description must not exceed 500 characters.")]
            public string Description { get; set; }

            [Column(TypeName = "decimal(6, 2)")]
            [Range(0.01, 500, ErrorMessage = "The Price must be between $0.01 and $500.00.")]
            public decimal Price { get; set; }
        public int? CategoryID { get; set; } // Cheie străină
        public Category? Category { get; set; } // Navigation property
                                              
        // Relație cu MenuItemType
        public int? MenuItemTypeID { get; set; } // Cheie străină
        public MenuItemType? MenuItemType { get; set; } // Navigation property

        public ICollection<Order>? Orders { get; set; }


    }
    }
