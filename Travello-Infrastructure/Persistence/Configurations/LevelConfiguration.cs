using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class LevelConfiguration : IEntityTypeConfiguration<Level>
{
    public void Configure(EntityTypeBuilder<Level> builder)
    {
        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(l => l.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(l => l.DiscountPercentage)
            .IsRequired()
            .HasColumnType("decimal(5,2)");
        builder.Property(l => l.IsFreeTransportation)
            .IsRequired();
        // Relationships
        builder.HasMany(l => l.Users)
            .WithOne(u => u.Level)
            .HasForeignKey(u => u.LevelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
