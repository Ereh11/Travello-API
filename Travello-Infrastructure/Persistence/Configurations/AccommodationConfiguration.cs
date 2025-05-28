using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class AccommodationConfiguration : IEntityTypeConfiguration<Accommodation>
{
    public void Configure(EntityTypeBuilder<Accommodation> builder)
    {
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(a => a.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(a => a.Capacity)
            .IsRequired();
        builder.Property(a => a.NumberOfRooms)
            .IsRequired();
        builder.Property(a => a.NumberOfBathroom)
            .IsRequired();
        builder.Property(a => a.AccommodationType)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(a => a.AccommodationView)
            .IsRequired()
            .HasConversion<string>();
        // Relationships
        builder.HasOne(a => a.Hotel)
            .WithMany(h => h.Accommodations)
            .HasForeignKey(a => a.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(a => a.Rooms)
            .WithOne(r => r.Accommodation)
            .HasForeignKey(r => r.AccommodationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
