using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Data;
using ResturantDelivery.Models;

namespace ResturantDelivery.Reposetories
{
    public class MenueRepo :GenericRepo<MenuItem,int>
    {
        private readonly ResturantDbContext db;
        public MenueRepo(ResturantDbContext _db) : base(_db)
        {
            db = _db;

        }

        // get menu items :  
        public async Task<List<MenuItem>> GetMenuByRestaurantIdAsync(int restaurantId)
        {
            return await db.MenuItems
                          .Where(m => m.RestaurantId == restaurantId)
                          .ToListAsync();
        }

    }
}
