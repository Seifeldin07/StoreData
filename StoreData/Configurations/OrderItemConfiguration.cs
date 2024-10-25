using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreData.Entities.OrderEntities;


namespace Store.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            {
                builder.OwnsOne(orderItem => orderItem.ProductItem, x =>
                {
                    x.WithOwner();
                });

            }
        }
    }
}
