using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Data;
using ResturantDelivery.Models;
using System;

namespace ResturantDelivery.Reposetories
{
    public class UserRepo : GenericRepo<User, int>
    {
        private readonly ResturantDbContext _context;

        public UserRepo(ResturantDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await db.Set<User>().FirstOrDefaultAsync(u => u.Email == email);

        }
    }
}