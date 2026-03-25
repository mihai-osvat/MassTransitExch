using System;
using System.Reflection;

namespace MassTransitExch.Modules.Clients.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
