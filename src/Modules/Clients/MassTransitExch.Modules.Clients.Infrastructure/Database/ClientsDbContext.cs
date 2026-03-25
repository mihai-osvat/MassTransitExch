using System;
using MassTransitExch.Modules.Clients.Application.Abstractions;
using MassTransitExch.Modules.Clients.Domain.Clients;
using MassTransitExch.Modules.Clients.Infrastructure.Clients;
using Microsoft.EntityFrameworkCore;

namespace MassTransitExch.Modules.Clients.Infrastructure.Database;

public sealed class ClientsDbContext(DbContextOptions<ClientsDbContext> options): DbContext(options), IUnitOfWork
{
    internal DbSet<Client> Clients {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("clients");
        modelBuilder.ApplyConfiguration(new ClientsConfiguration());
    }
}
