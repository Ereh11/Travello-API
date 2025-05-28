using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(r => r.RoomType)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(r => r.BedConfiguration)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(r => r.BathroomType)
            .IsRequired()
            .HasConversion<string>();

        // Relationships
        builder.HasOne(r => r.Accommodation)
            .WithMany(a => a.Rooms)
            .HasForeignKey(r => r.AccommodationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
