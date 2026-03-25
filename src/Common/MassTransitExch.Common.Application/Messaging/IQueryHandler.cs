using System;
using MediatR;

namespace MassTransitExch.Common.Application.Messaging;

public interface IQueryHandler<in T, U> : IRequestHandler<T, U> where T : IQuery<U>;