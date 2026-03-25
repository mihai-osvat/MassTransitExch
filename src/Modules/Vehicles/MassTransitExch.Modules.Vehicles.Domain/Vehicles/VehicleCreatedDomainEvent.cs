using System;
using MassTransitExch.Common.Domain;

namespace MassTransitExch.Modules.Vehicles.Domain.Vehicles;

public class VehicleCreatedDomainEvent(Guid vehicleId) : DomainEvent
{
    Guid VehicleId {get; init;} = vehicleId;
}
