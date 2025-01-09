
using System.ComponentModel.DataAnnotations;

namespace Menuzama1.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name must not exceed 100 characters.")]
        public string? FullName { get; set; }

        [StringLength(200, ErrorMessage = "Address must not exceed 50 characters.")]
        public string? Adress { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^0\d{8}$", ErrorMessage = "The phone number must start with '0' and have exactly 10 digits.")]
        public string Phone { get; set; }


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
