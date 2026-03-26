using MassTransit;
using RabbitMQ.Client;
using MassTransitExch.Common.Presentation.Endpoints;
using MassTransitExch.Modules.Vehicles.Application.Abstractions;
using MassTransitExch.Modules.Vehicles.Domain.Owners;
using MassTransitExch.Modules.Vehicles.Domain.Vehicles;
using MassTransitExch.Modules.Vehicles.Infrastructure.Database;
using MassTransitExch.Modules.Vehicles.Infrastructure.Owners;
using MassTransitExch.Modules.Vehicles.Infrastructure.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransitExch.Modules.Vehicles.Infrastructure;

public static class VehiclesModule
{
    public static IServiceCollection AddVehiclesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    public static void AddVehiclesTopology(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.ReceiveEndpoint("ClientsCreatedQueue", e =>
        {
           e.ConfigureConsumeTopology = false;

           e.Bind("ClientsExchange", binder =>
           {
                binder.ExchangeType = ExchangeType.Topic;
                binder.RoutingKey = "client.*.created";
           });

           e.Consumer<ClientCreatedIntegratedEventConsumer>(context);
        });
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VehiclesDbContext>((sp, options) =>
        {
           options.UseNpgsql(configuration.GetConnectionString("Database"),
           npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "vehicles"));
        });

        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<VehiclesDbContext>());

        return services;
    }
}
