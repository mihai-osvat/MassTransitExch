using System;
using MassTransitExch.Common.Application.Messaging;
using MassTransitExch.Modules.Vehicles.Application.Abstractions;
using MassTransitExch.Modules.Vehicles.Domain.Owners;

namespace MassTransitExch.Modules.Vehicles.Application.Owners.CreateOwner;

internal sealed class CreateOwnerCommandHandler(IOwnerRepository ownerRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateOwnerCommand>
{
    public async Task Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = Owner.Create(request.OwnerId, request.FirstName, request.LastName);

        ownerRepository.Insert(owner);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
