using System.Reflection;
using MassTransitExch.Modules.Clients.Infrastructure;
using MassTransitExch.Modules.Vehicles.Infrastructure;
using MassTransitExch.Common.Application;
using MassTransitExch.Common.Infrastructure.Configuration;
using MassTransitExch.Common.Infrastructure;
using MassTransitExch.Common.Presentation.Endpoints;

var builder = WebApplication.CreateBuilder(args);

Assembly[] moduleApplicationAssemblies = [
  MassTransitExch.Modules.Clients.Application.AssemblyReference.Assembly,
  MassTransitExch.Modules.Vehicles.Application.AssemblyReference.Assembly,  
];

string databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database");

builder.Services.AddApplication(moduleApplicationAssemblies);
builder.Services.AddInfrastructure(databaseConnectionString);

builder.Services.AddClientsModule(builder.Configuration);
builder.Services.AddVehiclesModule(builder.Configuration);

var app = builder.Build();
app.MapEndpoints();

app.Run();

public partial class Program;