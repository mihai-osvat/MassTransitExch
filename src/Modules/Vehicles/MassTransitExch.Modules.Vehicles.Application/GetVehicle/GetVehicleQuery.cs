using System;
using MassTransitExch.Common.Application.Messaging;

namespace MassTransitExch.Modules.Vehicles.Application.GetVehicle;

public sealed record GetVehicleQuery(Guid Id) : IQuery<VehicleResponse>;