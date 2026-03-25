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
using MassTransitExch.Modules.Clients.IntegrationEvents;
using RabbitMQ.Client;
using MassTransitExch.Common.Infrastructure.Outbox;

namespace MassTransitExch.Modules.Clients.Infrastructure;

public static class ClientsModule
{
    public static IServiceCollection AddClientsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
        return services;
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

        services.AddMassTransit(configure =>
        {
           configure.UsingRabbitMq((context, configuration) =>
           {
               configuration.Host("localhost", "/", h =>
               {
                   h.Username("guest");
                   h.Password("guest");
               });
               
               configuration.Publish<ClientCreatedIntegrationEvent>(x => x.ExchangeType = ExchangeType.Topic);
               configuration.Send<ClientCreatedIntegrationEvent>(x =>
               {
                    x.UseRoutingKeyFormatter(ctx => $"client.{ctx.Message.ClientId}.created");
               });
           });
        });

        return services;
    }
}
