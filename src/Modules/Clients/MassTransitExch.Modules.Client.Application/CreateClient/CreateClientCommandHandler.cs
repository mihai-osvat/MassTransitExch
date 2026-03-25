using System;
using MassTransitExch.Common.Application.EventBus;
using MassTransitExch.Common.Application.Messaging;
using MassTransitExch.Modules.Clients.Application.Abstractions;
using MassTransitExch.Modules.Clients.Domain.Clients;

namespace MassTransitExch.Modules.Clients.Application.CreateClient;

internal sealed class CreateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork, IEventBus eventBus) : ICommandHandler<CreateClientCommand, Guid>
{
    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = Client.Create(request.FirstName, request.LastName);
        clientRepository.Insert(client);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return client.Id;
    }
}
