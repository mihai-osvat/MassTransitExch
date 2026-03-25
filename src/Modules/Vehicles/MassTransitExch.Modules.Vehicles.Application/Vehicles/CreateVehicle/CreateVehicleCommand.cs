using System;
using MassTransitExch.Common.Application.Messaging;

namespace MassTransitExch.Modules.Vehicles.Application.Vehicles.CreateVehicle;

public sealed record CreateVehicleCommand(string Make, string Model, int Year) : ICommand<Guid>;