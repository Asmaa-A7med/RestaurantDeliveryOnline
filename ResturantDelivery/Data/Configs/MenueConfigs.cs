using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResturantDelivery.Models;

namespace ResturantDelivery.Configs
{
    public class MenueConfigs : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(m=>m.Id);
             builder.HasOne(m => m.Restaurant)
              .WithMany(r => r.MenuItems)
               .HasForeignKey(m => m.RestaurantId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
