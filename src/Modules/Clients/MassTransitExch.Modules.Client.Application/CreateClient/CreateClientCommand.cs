using System;
using System.Windows.Input;
using MassTransitExch.Common.Application.Messaging;

namespace MassTransitExch.Modules.Clients.Application.CreateClient;

public sealed record CreateClientCommand(string FirstName, string LastName): ICommand<Guid>;