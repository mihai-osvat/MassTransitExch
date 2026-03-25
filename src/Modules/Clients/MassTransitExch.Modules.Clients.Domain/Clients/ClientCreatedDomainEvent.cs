using System;
using MassTransitExch.Common.Domain;

namespace MassTransitExch.Modules.Clients.Domain.Clients;

public sealed class ClientCreatedDomainEvent(Guid clientId) : DomainEvent
{
    public Guid ClientId {get;init;} = clientId;
}
