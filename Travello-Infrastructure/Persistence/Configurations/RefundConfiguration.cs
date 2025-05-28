using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class RefundConfiguration : IEntityTypeConfiguration<Refund>
{
    public void Configure(EntityTypeBuilder<Refund> builder)
    {
        builder.Property(r => r.RefundPercentage)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(r => r.RefundDate)
            .HasColumnType("datetime")
            .IsRequired();
        builder.Property(r => r.Reason)
            .HasMaxLength(1000);
        builder.Property(r => r.RefundStatus)
            .IsRequired()
            .HasConversion<string>();
    }
}
