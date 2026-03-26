using System.Reflection;
using MassTransitExch.Modules.Clients.Infrastructure;
using MassTransitExch.Modules.Vehicles.Infrastructure;
using MassTransitExch.Common.Application;
using MassTransitExch.Common.Infrastructure.Configuration;
using MassTransitExch.Common.Infrastructure;
using MassTransitExch.Common.Presentation.Endpoints;
using MassTransitExch.Common.Infrastructure.EventBus;

var builder = WebApplication.CreateBuilder(args);

Assembly[] moduleApplicationAssemblies = [
  MassTransitExch.Modules.Clients.Application.AssemblyReference.Assembly,
  MassTransitExch.Modules.Vehicles.Application.AssemblyReference.Assembly,  
];

string databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database");
var rabbitMqSettings = new RabbitMqSettings(builder.Configuration.GetConnectionStringOrThrow("Queue"));

builder.Services.AddApplication(moduleApplicationAssemblies);

builder.Services.AddClientsModule(builder.Configuration);
builder.Services.AddVehiclesModule(builder.Configuration);

builder.Services.AddInfrastructure(
  databaseConnectionString,
  rabbitMqSettings,
  [
    ClientsModule.AddClientsTopology,
    VehiclesModule.AddVehiclesTopology,
  ]
);


var app = builder.Build();
app.MapEndpoints();

app.Run();

public partial class Program;