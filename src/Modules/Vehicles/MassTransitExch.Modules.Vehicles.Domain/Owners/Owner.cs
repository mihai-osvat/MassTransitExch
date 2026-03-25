using System;
using MassTransitExch.Common.Domain;

namespace MassTransitExch.Modules.Vehicles.Domain.Owners;

public sealed class Owner : Entity
{
    private Owner()
    {
        
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }    

    public static Owner Create(Guid id, string firstName, string lastName)
    {
        return new Owner
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        };
    }
}
