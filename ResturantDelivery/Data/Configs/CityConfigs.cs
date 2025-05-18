using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResturantDelivery.Models;

namespace ResturantDelivery.Configs
{
    public class CityConfigs: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c=> c.Id);

            builder.HasMany(c => c.Restaurants)
                 .WithOne(r => r.City)
                 .HasForeignKey(r => r.CityId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
        }
}
