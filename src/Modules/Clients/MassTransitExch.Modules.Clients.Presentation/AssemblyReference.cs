using System.Reflection;

namespace MassTransitExch.Modules.Clients.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
