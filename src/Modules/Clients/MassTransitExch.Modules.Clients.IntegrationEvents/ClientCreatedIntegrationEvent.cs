namespace MassTransitExch.Modules.Clients.IntegrationEvents;

public sealed class ClientCreatedIntegrationEvent
{
    public int ClientId { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public DateTime OccurredAt { get; init; }

    ClientCreatedIntegrationEvent(int clientId, string firstName, string lastName, DateTime occurredAt)
    {
        ClientId = clientId;
        FirstName = firstName;
        LastName = lastName;
        OccurredAt = occurredAt;
    }
}
