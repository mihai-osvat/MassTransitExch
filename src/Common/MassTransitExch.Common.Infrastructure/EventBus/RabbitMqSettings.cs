using System;

namespace MassTransitExch.Common.Infrastructure.EventBus;

public sealed record RabbitMqSettings(string Host, ushort Port = 5672, string VirtualHost = "AutoService", string Username = "auto-svc", string Password = "Th1rt3en#");
