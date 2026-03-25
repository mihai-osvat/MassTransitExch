using System;
using System.Net;
using MassTransitExch.Common.Presentation.Endpoints;
using MassTransitExch.Modules.Clients.Application.GetClient;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace MassTransitExch.Modules.Clients.Presentation.Users;

public class GetClient : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("clients/{id}", async (Guid id, ISender sender)=>
        {
           var result = await sender.Send(new GetClientQuery(id));

           return result;
        });
    }
}
