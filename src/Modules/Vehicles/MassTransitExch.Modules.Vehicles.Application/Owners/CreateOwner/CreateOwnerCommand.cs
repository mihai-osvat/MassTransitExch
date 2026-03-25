using System;
using MassTransitExch.Common.Application.Messaging;

namespace MassTransitExch.Modules.Vehicles.Application.Owners.CreateOwner;

public sealed record CreateOwnerCommand(Guid OwnerId, string FirstName, string LastName): ICommand;