using FuelStation.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configuration;

internal class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
{
    public void Configure(EntityTypeBuilder<TransactionLine> builder)
    {
        builder.HasKey(tLine => tLine.ID);
        builder.Property(transactionLine => transactionLine.ID);
        builder.Property(tLine => tLine.ItemPrice).HasColumnType("decimal(10,2)");
        builder.Property(tLine => tLine.NetValue).HasColumnType("decimal(10,2)");
        builder.Property(tLine => tLine.DiscountPercentage).HasColumnType("decimal(8,3)");
        builder.Property(tLine => tLine.DiscountValue).HasColumnType("decimal(10,2)");
        builder.Property(tLine => tLine.TotalValue).HasColumnType("decimal(10,2)");

        builder.HasOne(tLine => tLine.Transaction)
                .WithMany(transaction => transaction.TransactionLines)
                .HasForeignKey(tLine => tLine.TransactionID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(tLine => tLine.Item)
                .WithMany(item => item.TransactionLines)
                .HasForeignKey(transaction => transaction.ItemID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
    }
}