using System;
using MassTransitExch.Modules.Clients.Infrastructure.Clients;
using MassTransitExch.Modules.Vehicles.Application.Abstractions;
using MassTransitExch.Modules.Vehicles.Domain.Vehicles;
using MassTransitExch.Modules.Vehicles.Domain.Owners;
using Microsoft.EntityFrameworkCore;

namespace MassTransitExch.Modules.Vehicles.Infrastructure.Database;

public class VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Vehicle> Vehicles {get;set;}
    internal DbSet<Owner> Owners {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("vehicles");
        modelBuilder.ApplyConfiguration(new VehiclesConfiguration());
    }
}
