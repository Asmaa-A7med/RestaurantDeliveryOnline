using ResturantDelivery.Data;
using ResturantDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace ResturantDelivery.Reposetories
{
    public class CustomerRepo : GenericRepo<Customer, int>, ICustomerRepo
    {
        private readonly ResturantDbContext _context;

        public CustomerRepo(ResturantDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }
    }

    }
