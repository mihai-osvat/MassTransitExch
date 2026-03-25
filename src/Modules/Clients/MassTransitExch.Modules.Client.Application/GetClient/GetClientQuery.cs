using System;
using MassTransitExch.Common.Application.Messaging;

namespace MassTransitExch.Modules.Clients.Application.GetClient;

public sealed record GetClientQuery(Guid Id) : IQuery<ClientResponse>;