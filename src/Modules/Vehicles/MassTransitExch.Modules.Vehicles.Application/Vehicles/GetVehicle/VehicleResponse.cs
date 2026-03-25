using System;

namespace MassTransitExch.Modules.Vehicles.Application.Vehicles.GetVehicle;

public sealed record VehicleResponse(Guid Id, string Make, string Model, int Year);