using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
       
        builder.Property(b => b.CheckInDate)
            .IsRequired();
        builder.Property(b => b.CheckOutDate)
            .IsRequired();
        builder.Property(b => b.NumberOfGuests)
            .IsRequired();
        builder.Property(b => b.TotalPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        // Relationships
        builder.HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Hotel)
            .WithMany(h => h.Bookings)
            .HasForeignKey(b => b.HotelId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Payment)
            .WithOne()
            .HasForeignKey<Booking>(b => b.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(b => b.Refund)
           .WithOne(r => r.Booking)
           .HasForeignKey<Refund>(r => r.BookingId)
           .OnDelete(DeleteBehavior.Cascade);

    }
}

