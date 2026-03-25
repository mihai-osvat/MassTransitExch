using System;
using MassTransitExch.Common.Application.EventBus;
using MassTransitExch.Common.IntegrationEvents;
using MediatR;

namespace MassTransitExch.Modules.Vehicles.Presentation.Owners;

public class ClientCreatedIntegratedEventHandler : IntegrationEventHandler<ClientCreatedIntegrationEvent>
{
    public override Task Handle(ClientCreatedIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
