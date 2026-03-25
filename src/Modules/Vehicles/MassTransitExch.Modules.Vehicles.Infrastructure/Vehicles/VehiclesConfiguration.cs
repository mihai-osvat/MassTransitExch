using System;
using MassTransitExch.Modules.Vehicles.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MassTransitExch.Modules.Clients.Infrastructure.Clients;

internal sealed class VehiclesConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Make).HasMaxLength(20);
        builder.Property(v => v.Model).HasMaxLength(20);
    }
}
