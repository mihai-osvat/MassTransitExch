using System;

namespace MassTransitExch.Modules.Vehicles.Domain.Owners;

public interface IOwnerRepository
{
    Task<Owner?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Owner owner);
}
