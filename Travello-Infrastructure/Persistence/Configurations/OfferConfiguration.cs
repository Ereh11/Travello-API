using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.Property(o => o.Title)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(o => o.DiscountValue)
            .IsRequired();
        builder.Property(o => o.PromoCode)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(o => o.ExpiryDate)
            .IsRequired();
        builder.Property(o => o.StartDate)
            .IsRequired();
        // Relationships
        builder.HasOne(o => o.Image)
            .WithMany()
            .HasForeignKey(o => o.ImageId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(o => o.UserOffers)
            .WithOne(uo => uo.Offer)
            .HasForeignKey(uo => uo.OfferId);
    }
}
