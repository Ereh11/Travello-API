using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class UserReviewConfiguration : IEntityTypeConfiguration<UserReview>
{
    public void Configure(EntityTypeBuilder<UserReview> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.HotelId });
        builder.Property(ur => ur.Comment)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(ur => ur.CreatedAt)
            .IsRequired();
        builder.Property(ur => ur.UpdatedAt)
            .IsRequired(false);
        // Relationships
        builder.Property(ur => ur.Rating)
            .IsRequired()
            .HasDefaultValue(1);
        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserReviews)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(ur => ur.Hotel)
            .WithMany(h => h.UserReviews)
            .HasForeignKey(ur => ur.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

