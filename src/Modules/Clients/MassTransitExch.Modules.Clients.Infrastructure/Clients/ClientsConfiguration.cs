using System;
using MassTransitExch.Modules.Clients.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MassTransitExch.Modules.Clients.Infrastructure.Clients;

internal sealed class ClientsConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).HasMaxLength(20);
        builder.Property(c => c.LastName).HasMaxLength(20);
    }
}
