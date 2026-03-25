using System;
using MassTransitExch.Common.Application.Messaging;

namespace MassTransitExch.Modules.Vehicles.Application.Vehicles.GetVehicle;

public sealed record GetVehicleQuery(Guid Id) : IQuery<VehicleResponse>;