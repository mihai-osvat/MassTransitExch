using System;
using MassTransitExch.Modules.Clients.Domain.Clients;
using MassTransitExch.Modules.Clients.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MassTransitExch.Modules.Clients.Infrastructure.Clients;

internal sealed class ClientRepository(ClientsDbContext context) : IClientRepository
{
    public async Task<Client?> GetClientAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Clients.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public void Insert(Client client)
    {
        context.Clients.Add(client);
    }
}
