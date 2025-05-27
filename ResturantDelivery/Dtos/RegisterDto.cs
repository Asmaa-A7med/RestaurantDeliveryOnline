using System.ComponentModel.DataAnnotations;

namespace ResturantDelivery.Dtos
{
    public class RegisterDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.(com)$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$")]
        public string Phone { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+[\]{};':""\\|,.<>/?]).{8,}$")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
