using System;
using MediatR;

namespace MassTransitExch.Common.Application.Messaging;

public interface IQuery<T> : IRequest<T>;