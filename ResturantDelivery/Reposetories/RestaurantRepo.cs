using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Data;
using ResturantDelivery.Models;

namespace ResturantDelivery.Reposetories
{
    public class RestaurantRepo :GenericRepo<Restaurant,int>
    {
        private readonly ResturantDbContext db;
        public RestaurantRepo(ResturantDbContext _db) : base(_db)
        {
            db = _db;

        }

        // get all resturant :
        public async Task<List<Restaurant>> GetAllWithCityAsync()
        {
            return await db.Restaurants
                 
              //  .Include(r => r.MenuItems)  
                .ToListAsync();
        }

        // search resturant :
        public async Task<List<Restaurant>> SearchRestaurantsAsync(string? name, string? cityName)
        {
            var query = db.Restaurants
                          .Include(r => r.City)  
                          .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(r => r.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                query = query.Where(r => r.City.Name.Contains(cityName));
            }

            return await query.ToListAsync();
        }
    }
}
