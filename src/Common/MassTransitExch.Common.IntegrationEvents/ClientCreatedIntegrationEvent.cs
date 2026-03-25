using MassTransitExch.Common.Application.EventBus;

namespace MassTransitExch.Common.IntegrationEvents;

public sealed class ClientCreatedIntegrationEvent : IntegrationEvent
{
    public Guid ClientId { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public DateTime OccurredAt { get; init; }

    public ClientCreatedIntegrationEvent(Guid clientId, string firstName, string lastName, DateTime occurredAtUtc)
    : base(clientId, occurredAtUtc)
    {
        ClientId = clientId;
        FirstName = firstName;
        LastName = lastName;
        OccurredAt = occurredAtUtc;
    }
}
