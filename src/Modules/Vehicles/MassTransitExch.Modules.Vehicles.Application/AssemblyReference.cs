using System;
using System.Reflection;

namespace MassTransitExch.Modules.Vehicles.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
