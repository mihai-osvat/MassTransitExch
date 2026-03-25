using System;
using MediatR;

namespace MassTransitExch.Common.Application.Messaging;

public interface ICommand : IRequest, IBaseCommand;

public interface ICommand<T>: IRequest<T>, IBaseCommand;

public interface IBaseCommand;