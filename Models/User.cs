using System.ComponentModel.DataAnnotations;

namespace Menuzama1.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; } // Opțional

        [MaxLength(50)]
        public string Role { get; set; } = "User";

        public int LoyaltyPoints { get; set; } = 0;
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        // Relație cu Order
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
