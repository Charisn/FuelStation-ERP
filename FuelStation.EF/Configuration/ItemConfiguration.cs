using FuelStation.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configuration;

internal class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(item => item.ID);

        builder.Property(item => item.Code).HasMaxLength(100);
        builder.Property(item => item.Description).HasMaxLength(300);
        builder.Property(item => item.Price).HasColumnType("decimal(10,2)");
        builder.Property(item => item.Cost).HasColumnType("decimal(10,2)");

        builder.HasIndex(item => item.Status);
    }
}
