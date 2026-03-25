using System;
using MassTransitExch.Modules.Vehicles.Domain.Owners;
using MassTransitExch.Modules.Vehicles.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MassTransitExch.Modules.Vehicles.Infrastructure.Owners;

internal sealed class OwnerRepository(VehiclesDbContext context) : IOwnerRepository
{
    public async Task<Owner?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Owners.SingleOrDefaultAsync(o => o.Id == id);
    }

    public void Insert(Owner owner)
    {
        context.Owners.Add(owner);
    }
}
