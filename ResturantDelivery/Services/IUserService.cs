using ResturantDelivery.Models;

namespace ResturantDelivery.Services
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
    }
}
