using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Data.Configs;
using ResturantDelivery.Models;

namespace ResturantDelivery.Data
{
    public class ResturantDbContext:DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {
        }


        public DbSet<City> Cities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfigs());
            modelBuilder.ApplyConfiguration(new RestaurantConfigs());
            modelBuilder.ApplyConfiguration(new MenueConfigs());
            modelBuilder.ApplyConfiguration(new CustomerConfigs());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailConfigs());
        }
    }
}

