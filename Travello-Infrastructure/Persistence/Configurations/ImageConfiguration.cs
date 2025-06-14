﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
       builder.Property(i => i.ImageURL)
            .IsRequired()
            .HasMaxLength(500);
    }
}
