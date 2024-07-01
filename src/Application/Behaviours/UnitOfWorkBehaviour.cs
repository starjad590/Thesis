﻿using Application.Abstractions.Messaging;
using Application.Repositories.Base;
using MediatR;

namespace Application.Behaviours;

public sealed class UnitOfWorkBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehaviour(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (IsNotCommand())
        {
            return await next();
        }

        var result = await next();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    private static bool IsNotCommand() => !typeof(TRequest).GetInterfaces().Any(i => i == typeof(ICommand));
}
