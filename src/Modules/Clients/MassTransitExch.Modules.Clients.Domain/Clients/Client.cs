using System;
using MassTransitExch.Common.Domain;

namespace MassTransitExch.Modules.Clients.Domain.Clients;

public class Client : Entity
{
    public Guid Id { get; init; }

    public string FirstName {get; private set;}
    public string LastName {get; private set;}

    private Client() {}

    public static Client Create(string firstName, string lastName)
    {
        var client = new Client()
        {
            FirstName = firstName,
            LastName = lastName,
        };

        client.Raise(new ClientCreatedDomainEvent(client.Id));
        
        return client;
    }
}
