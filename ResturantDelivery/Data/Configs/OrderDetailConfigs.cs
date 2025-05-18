using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResturantDelivery.Models;

namespace ResturantDelivery.Configs
{
    public class OrderDetailConfigs : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            //Order item with order :
           builder.HasOne(oi => oi.Order)
             .WithMany(o => o.OrderDetails)
             .HasForeignKey(oi => oi.OrderId)
             .OnDelete(DeleteBehavior.Cascade);

            // order detail with menue item , avoid deleting item if order exist
             builder.HasOne(oi => oi.MenuItem)
            .WithMany()
            .HasForeignKey(oi => oi.MenuItemId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
