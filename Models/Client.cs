
using System.ComponentModel.DataAnnotations;

namespace Menuzama1.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Numele trebuie sa inceapa cu majuscula ")]
       
        [StringLength(30, MinimumLength = 3)]
        public string? FullName { get; set; }

        [StringLength(200, ErrorMessage = "Address must not exceed 50 characters.")]
        public string? Adress { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        // [Required(ErrorMessage = "Phone number is required.")]
        //[RegularExpression(@"^0\d{8}$", ErrorMessage = "The phone number must start with '0' and have exactly 10 digits.")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]

        public string? Phone { get; set; }


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
