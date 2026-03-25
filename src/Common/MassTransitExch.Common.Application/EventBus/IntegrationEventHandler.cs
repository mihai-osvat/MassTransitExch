using System;
using static MassTransitExch.Common.Application.EventBus.IIntegrationEventHandler;

namespace MassTransitExch.Common.Application.EventBus;

public abstract class IntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler<TIntegrationEvent> where TIntegrationEvent : IIntegrationEvent
{
    public abstract Task Handle(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);

    public Task Handle(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default) => 
        Handle((TIntegrationEvent)integrationEvent, cancellationToken);
}
