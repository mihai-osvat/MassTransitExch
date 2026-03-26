using MassTransit;
using MassTransitExch.Common.Application.EventBus;
using MassTransitExch.Common.Infrastructure.EventBus;
using MassTransitExch.Common.Infrastructure.Outbox;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MassTransitExch.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        string databaseConnectionString,
        RabbitMqSettings rabbitMqSettings,
        Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator>[] topologyConfigurators)
    {
        services.TryAddSingleton<IEventBus, EventBus.EventBus>();
        services.TryAddSingleton<InsertOutboxMessageInterceptor>();

        services.AddMassTransit(configure =>
        {
            configure.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqSettings.Host, rabbitMqSettings.Port, rabbitMqSettings.VirtualHost, h =>
                {
                    h.Username(rabbitMqSettings.Username);
                    h.Password(rabbitMqSettings.Password);
                });

                foreach(Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> topologyConfigurator in topologyConfigurators)
                {
                    topologyConfigurator(context, cfg);
                }
            });
        });

        return services;
    }
}
