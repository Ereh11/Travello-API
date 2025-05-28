using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;


public class PassportConfiguration : IEntityTypeConfiguration<Passport>
{
    public void Configure(EntityTypeBuilder<Passport> builder)
    {
        builder.Property(p => p.PassportNumber)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(p => p.PassportName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.ExpiryDate)
            .IsRequired();
        builder.Property(p => p.CountryOfProduction)
            .IsRequired()
            .HasMaxLength(50);
    }
}
