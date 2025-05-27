using ResturantDelivery.Models;

namespace ResturantDelivery.Reposetories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
