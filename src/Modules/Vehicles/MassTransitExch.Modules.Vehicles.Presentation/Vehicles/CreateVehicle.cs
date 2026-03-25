using System;
using MassTransitExch.Common.Presentation.Endpoints;
using MassTransitExch.Modules.Vehicles.Application.CreateVehicle;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace MassTransitExch.Modules.Vehicles.Presentation.Vehicles;

internal sealed class CreateVehicle : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("vehicles", async (Request request, ISender sender) =>
        {
            Guid result = await sender.Send(new CreateVehicleCommand(request.Make, request.Model, request.Year));

            return result;
        });
    }

    internal sealed class Request
    {
        public string Make { get; init; }

        public string Model { get; init; }

        public int Year { get; init; }
    }
}
