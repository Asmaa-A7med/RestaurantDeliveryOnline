using System.ComponentModel.DataAnnotations;

namespace ResturantDelivery.Dtos
{
    public class CustomerLoginDto
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.(com)$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+[\]{};':""\\|,.<>/?]).{8,}$")]
        public string Password {  get; set; }

    }
}
