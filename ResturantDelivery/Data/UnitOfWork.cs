using ResturantDelivery.Models;
using ResturantDelivery.Reposetories;

namespace ResturantDelivery.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly ResturantDbContext _context;
        
        public RestaurantRepo Restaurants { get; }

        public citiyRepo Cities { get; }

        public MenueRepo MenuItems { get; }

      


        public GenericRepo<Order, int> Orders { get; }
        public CustomerRepo Customers { get; }


        public GenericRepo<OrderDetail, int> OrderDetails { get; }

        public UnitOfWork(ResturantDbContext context)
        {
            _context = context;
            Cities = new citiyRepo(_context);

            Restaurants = new RestaurantRepo(_context);

            MenuItems = new MenueRepo(_context);
            
            Customers = new CustomerRepo(context);

            Orders = new GenericRepo<Order, int>(_context);
            OrderDetails = new GenericRepo<OrderDetail, int>(_context);
        }

        // save changes :
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // end connection with dbContext 
        public void Dispose()
        {
            _context.Dispose();  
        }
    }
}
