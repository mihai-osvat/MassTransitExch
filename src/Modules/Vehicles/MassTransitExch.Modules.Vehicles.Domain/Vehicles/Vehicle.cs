using System;
using MassTransitExch.Common.Domain;

namespace MassTransitExch.Modules.Vehicles.Domain.Vehicles;

public class Vehicle : Entity
{
    private Vehicle()
    {
        
    }

    public Guid Id {get; init;}

    public string Make {get; private set;}

    public string Model { get; private set; }

    public int Year { get; private set; }

    public static Vehicle Create(string make, string model, int year)
    {
        var vehicle = new Vehicle()
        {
            Id = Guid.NewGuid(),
            Make = make,
            Model = model,
            Year = year,
        };

        vehicle.Raise(new VehicleCreatedDomainEvent(vehicle.Id));

        return vehicle;
    }
}
