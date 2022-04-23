using FuelStation.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configuration;

internal class LoginConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.HasKey(login => login.ID);

        builder.Property(login => login.Username).HasMaxLength(50);
        builder.Property(login => login.Password).HasMaxLength(50);
        builder.Property(login => login.Token).HasMaxLength(50);
    }
}
