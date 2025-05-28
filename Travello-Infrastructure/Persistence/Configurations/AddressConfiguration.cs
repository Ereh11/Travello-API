using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(a => a.State)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(a => a.Country)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(a => a.ZipCode)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(a => a.Government)
            .IsRequired()
            .HasMaxLength(50);
    }
}
