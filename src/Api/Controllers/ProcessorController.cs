using Api.Extensions;
using Application.UseCases.Processors.Commands.Add;
using Application.UseCases.Processors.Commands.Delete;
using Application.UseCases.Processors.Commands.Update;
using Application.UseCases.Processors.Queries.GetAll;
using Application.UseCases.Processors.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/processor/")]
public class ProcessorController(ISender sender) : ControllerWithMediatR(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetProcessorAsync([FromQuery] GetProcessorByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetProcessorsAsync(CancellationToken cancellationToken)
    {
        var result = await Send(new GetAllProcessorsQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPost]
    public async Task<IActionResult> AddProcessorAsync([FromBody] AddProcessorCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateProcessorAsync([FromBody] UpdateProcessorCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteProcessorAsync([FromRoute] DeleteProcessorCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }
}
