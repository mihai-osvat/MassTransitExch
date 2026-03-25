using System;
using MassTransitExch.Modules.Vehicles.Domain.Vehicles;
using MassTransitExch.Modules.Vehicles.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MassTransitExch.Modules.Vehicles.Infrastructure.Vehicles;

internal sealed class VehicleRepository(VehiclesDbContext context) : IVehicleRepository
{
    public async Task<Vehicle?> GetVehicleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Vehicles.SingleOrDefaultAsync(v => v.Id == id);
    }

    public void Insert(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
    }
}
