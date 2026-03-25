using System;
using MassTransitExch.Common.Presentation.Endpoints;
using MassTransitExch.Modules.Vehicles.Application.Vehicles.GetVehicle;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace MassTransitExch.Modules.Vehicles.Presentation.Vehicles;

public sealed class GetVehicle : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("vehicles/{id}", async (Guid id, ISender sender) =>
        {
            return await sender.Send(new GetVehicleQuery(id));
        });
    }
}
