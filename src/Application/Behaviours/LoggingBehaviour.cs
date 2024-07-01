using Application.Repositories.Base;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Behaviours;

internal class LoggingBehaviour<TRequest, TResponse> :
IPipelineBehavior<TRequest, TResponse>
where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        _logger.LogInformation($"Starting request : {nameof(request)}");

        var result = await next();

        stopWatch.Stop();
        _logger.LogInformation($"Ending request : {nameof(request)} - Time elapsed : {stopWatch.Elapsed}");
        return result;
    }
}