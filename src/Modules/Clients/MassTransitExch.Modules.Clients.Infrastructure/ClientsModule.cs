using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransitExch.Modules.Clients.Domain.Clients;
using MassTransitExch.Modules.Clients.Infrastructure.Clients;
using Microsoft.EntityFrameworkCore;
using MassTransitExch.Modules.Clients.Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Migrations;
using MassTransitExch.Modules.Clients.Application.Abstractions;
using MassTransitExch.Common.Presentation.Endpoints;
using MassTransit;
using RabbitMQ.Client;
using MassTransitExch.Common.Infrastructure.Outbox;
using MassTransitExch.Common.Application.EventBus;
using MassTransitExch.Common.IntegrationEvents;

namespace MassTransitExch.Modules.Clients.Infrastructure;

public static class ClientsModule
{
    public static IServiceCollection AddClientsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
        services.AddInfrastructure(configuration);
        return services;
    }


    public static void AddClientsTopology(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.Publish<IIntegrationEvent>(c => c.Exclude = true);
        configurator.Publish<IntegrationEvent>(c => c.Exclude = true);
        configurator.Message<ClientCreatedIntegrationEvent>(c => c.SetEntityName("ClientsExchange"));
        configurator.Publish<ClientCreatedIntegrationEvent>(p =>
        {
            p.ExchangeType = ExchangeType.Topic;
            p.Durable = true;
        });
        configurator.Send<ClientCreatedIntegrationEvent>(s =>
        {
            s.UseRoutingKeyFormatter(ctx => $"client.{ctx.Message.ClientId}.created");
        });
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ClientsDbContext>((sp, options) => 
            options
                .UseNpgsql(configuration.GetConnectionString("Database"), npgOptions => npgOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "clients"))
                .AddInterceptors(sp.GetRequiredService<InsertOutboxMessageInterceptor>())
            );
                

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ClientsDbContext>());

        return services;
    }
}
