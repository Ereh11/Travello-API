using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(p => p.PaymentMethod)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(p => p.PaymentDate)
            .HasColumnType("datetime");
        builder.Property(p => p.TransactionID)
            .IsRequired()
            .HasMaxLength(100);
    }
}
