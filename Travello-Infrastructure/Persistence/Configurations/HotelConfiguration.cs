using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class HotelConfiguratio : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(h => h.Description)
            .IsRequired()
            .HasMaxLength(3000);
        builder.Property(h => h.Stars)
            .IsRequired();
        // Relationships
        builder.HasOne(h => h.Address)
            .WithMany()
            .HasForeignKey(h => h.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(h => h.Images)
            .WithOne(i => i.Hotel)
            .HasForeignKey(i => i.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(h => h.HotelFacilities)
            .WithOne(hf => hf.Hotel)
            .HasForeignKey(hf => hf.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(h => h.UserReviews)
            .WithOne(ur => ur.Hotel)
            .HasForeignKey(ur => ur.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(h => h.Accommodations)
            .WithOne(a => a.Hotel)
            .HasForeignKey(a => a.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
