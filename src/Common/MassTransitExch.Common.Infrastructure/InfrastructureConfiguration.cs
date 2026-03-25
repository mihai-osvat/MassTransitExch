using MassTransit;
using MassTransitExch.Common.Application.EventBus;
using MassTransitExch.Common.Infrastructure.Outbox;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MassTransitExch.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string databaseConnectionString)
    {
        services.TryAddSingleton<IEventBus, EventBus.EventBus>();
        services.TryAddSingleton<InsertOutboxMessageInterceptor>();

        return services;
    }
}
