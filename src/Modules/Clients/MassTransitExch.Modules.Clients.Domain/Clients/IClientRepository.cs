using System;

namespace MassTransitExch.Modules.Clients.Domain.Clients;

public interface IClientRepository
{
    Task<Client?> GetClientAsync(Guid id,  CancellationToken cancellationToken = default);
    void Insert(Client client);
}
