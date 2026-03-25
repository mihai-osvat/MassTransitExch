using System;
using MassTransitExch.Common.Application.Messaging;
using MassTransitExch.Modules.Clients.Domain.Clients;

namespace MassTransitExch.Modules.Clients.Application.GetClient;

internal sealed class GetClientQueryHandler(IClientRepository clientRepository) : IQueryHandler<GetClientQuery, ClientResponse>
{
    public async Task<ClientResponse> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        Client? client = await clientRepository.GetClientAsync(request.Id);

        if (client is not null)
        {
            return new ClientResponse(client.Id, client.FirstName, client.LastName);
        }

        return null;
    }
}
