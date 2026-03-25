using System;
using MassTransitExch.Common.Application.Messaging;
using MassTransitExch.Modules.Vehicles.Application.Abstractions;
using MassTransitExch.Modules.Vehicles.Domain.Vehicles;

namespace MassTransitExch.Modules.Vehicles.Application.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateVehicleCommand, Guid>
{
    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = Vehicle.Create(request.Make, request.Model, request.Year);

        vehicleRepository.Insert(vehicle);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return vehicle.Id;
    }
}
