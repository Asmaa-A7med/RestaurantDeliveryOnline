using ResturantDelivery.Models;

namespace ResturantDelivery.Reposetories
{
    public interface ICustomerRepo
    {
        Task<Customer?> GetByEmailAsync(string email);
    }
}
