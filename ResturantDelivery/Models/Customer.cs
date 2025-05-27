namespace ResturantDelivery.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
        public string Email { get; set; }    
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

    }
}
