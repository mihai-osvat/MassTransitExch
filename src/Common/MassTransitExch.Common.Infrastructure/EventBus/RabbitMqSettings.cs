using System;

namespace MassTransitExch.Common.Infrastructure.EventBus;

public sealed record RabbitMqSettings(string Host, ushort Port = 5672, string VirtualHost = "/", string Username = "guest", string Password = "guest");
