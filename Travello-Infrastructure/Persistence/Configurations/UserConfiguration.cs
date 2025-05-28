using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.Gender)
            .IsRequired();
        builder.Property(u => u.DateOfBirth)
            .IsRequired();
        // Relationships
        builder.HasMany(u => u.UserOffers)
            .WithOne(uo => uo.User)
            .HasForeignKey(uo => uo.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(u => u.Passport)
            .WithOne(p => p.User)
            .HasForeignKey<Passport>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(u => u.ProfileImage)
            .WithOne()
            .HasForeignKey<User>(u => u.ProfileImageId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(u => u.Address)
            .WithOne()
            .HasForeignKey<User>(u => u.AddressId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(u => u.UserReviews)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(u => u.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
