using System;

namespace MassTransitExch.Modules.Clients.Application.GetClient;

public sealed record ClientResponse(Guid Id, string FirstName, string LastName);
