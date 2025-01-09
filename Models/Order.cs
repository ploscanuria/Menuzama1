using System.ComponentModel.DataAnnotations;

namespace Menuzama1.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Client selection is required.")]
        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        [Required(ErrorMessage = "Menu item selection is required.")]
        public int? MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Order Date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        // Proprietăți suplimentare (calculate)
        public string Description => MenuItem?.Description ?? "N/A";
        public decimal Price => MenuItem?.Price ?? 0;
    }
}
