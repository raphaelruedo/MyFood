using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFood.Domain.Models;

namespace MyFood.Infra.Data.Mapping
{
    public class RestaurantMap : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Description)
               .HasMaxLength(250);

            builder.Property(r => r.IsActive)
               .IsRequired();

            builder.HasOne(r => r.Expertise)
             .WithMany(e => e.Restaurants)
             .HasForeignKey(r => r.ExpertiseId);

            builder.HasOne(r => r.Address)
             .WithMany(e => e.Restaurants)
             .HasForeignKey(r => r.AddressId);
        }
    }
}
