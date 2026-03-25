using System;

namespace MassTransitExch.Modules.Vehicles.Domain.Vehicles;

public interface IVehicleRepository
{
    Task<Vehicle?> GetVehicleAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Vehicle vehicle);
}
