using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFood.Domain.Models;

namespace MyFood.Infra.Data.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Unit)
                .IsRequired();

            builder.Property(oi => oi.Discount);

            builder.HasOne(oi => oi.Product)
              .WithMany(p => p.OrderItems)
              .HasForeignKey(oi => oi.ProductId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.Order)
              .WithMany(p => p.OrderItens)
              .HasForeignKey(oi => oi.OrderId);
        }
    }
}
