using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResturantDelivery.Models;

namespace ResturantDelivery.Configs
{
    public class RestaurantConfigs : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {

            builder.HasKey(c => c.Id);
            builder.HasOne(r => r.City)
    .WithMany(c => c.Restaurants)
    .HasForeignKey(r => r.CityId)
    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
