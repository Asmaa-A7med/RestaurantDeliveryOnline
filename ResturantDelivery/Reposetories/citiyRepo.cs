using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Data;
using ResturantDelivery.Models;

namespace ResturantDelivery.Reposetories
{
    public class citiyRepo:GenericRepo<City,int>
    {
        private readonly ResturantDbContext db;
        public citiyRepo(ResturantDbContext _db) : base(_db)
        {
            db = _db;

        }
        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await db.Cities.ToListAsync();
        }
    }
}
