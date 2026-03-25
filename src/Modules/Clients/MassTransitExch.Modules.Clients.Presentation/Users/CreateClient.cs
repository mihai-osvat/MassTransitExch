using System;
using MassTransitExch.Common.Presentation.Endpoints;
using MassTransitExch.Modules.Clients.Application.CreateClient;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace MassTransitExch.Modules.Clients.Presentation.Users;

internal sealed class CreateClient : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("clients", async (Request request, ISender sender) =>
        {
           Guid result = await sender.Send(new CreateClientCommand(
            request.FirstName,
            request.LastName
           ));

           return result;
        });
    }

    internal sealed class Request
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }
    }
}
