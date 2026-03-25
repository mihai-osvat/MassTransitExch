using Microsoft.AspNetCore.Routing;

namespace MassTransitExch.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
