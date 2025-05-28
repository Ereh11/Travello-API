using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        builder.ToTable("Facilities");
        builder.HasKey(f => f.FacilityId);
        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(f => f.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(f => f.IsFree)
            .IsRequired();
        builder.Property(f => f.Price)
            .HasColumnType("decimal(18,2)");
        // Relationship
        builder.HasMany(f => f.HotelFacilities)
            .WithOne(hf => hf.Facility)
            .HasForeignKey(hf => hf.FacilityId);
    }
}
