using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class UserOfferConfiguration : IEntityTypeConfiguration<UserOffer>
{
    public void Configure(EntityTypeBuilder<UserOffer> builder)
    {
        builder.HasKey(uo => new { uo.UserId, uo.OfferId });
        builder.Property(uo => uo.DateOfActivate)
            .IsRequired()
            .HasColumnType("datetime");
        // Relationships
        builder.HasOne(uo => uo.User)
            .WithMany(u => u.UserOffers)
            .HasForeignKey(uo => uo.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(uo => uo.Offer)
            .WithMany(o => o.UserOffers)
            .HasForeignKey(uo => uo.OfferId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
