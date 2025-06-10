using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;
public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
{
    public void Configure(EntityTypeBuilder<HotelImage> builder)
    {
        builder.HasKey(i => new { i.ImageId, i.HotelId });
        builder.Property(i => i.ImageId)
             .ValueGeneratedOnAdd()
             .IsRequired();
        builder.Property(i => i.ImageURL)
             .IsRequired()
             .HasMaxLength(500);
        builder.HasOne(i => i.Hotel)
            .WithMany(h => h.Images)
            .HasForeignKey(i => i.HotelId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
