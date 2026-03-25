using System;
using MassTransitExch.Common.Application.Messaging;
using MassTransitExch.Modules.Vehicles.Domain.Vehicles;

namespace MassTransitExch.Modules.Vehicles.Application.GetVehicle;

internal sealed class GetVehicleQueryHandler(IVehicleRepository vehicleRepository) : IQueryHandler<GetVehicleQuery, VehicleResponse>
{
    public async Task<VehicleResponse> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
    {
        Vehicle? vehicle = await vehicleRepository.GetVehicleAsync(request.Id);

        if (vehicle is not null)
        {
            return new VehicleResponse(vehicle.Id, vehicle.Make, vehicle.Model, vehicle.Year);
        }

        return null;
    }
}
