using System;
using MassTransit;
using MassTransitExch.Common.IntegrationEvents;
using MassTransitExch.Modules.Vehicles.Application.Owners.CreateOwner;
using MediatR;

namespace MassTransitExch.Modules.Vehicles.Infrastructure.Owners;

internal sealed class ClientCreatedIntegratedEventConsumer(ISender sender) : IConsumer<ClientCreatedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<ClientCreatedIntegrationEvent> context)
    {
        ClientCreatedIntegrationEvent integrationEvent = context.Message;

        await sender.Send(new CreateOwnerCommand(integrationEvent.ClientId, integrationEvent.FirstName, integrationEvent.LastName));
    }
}
