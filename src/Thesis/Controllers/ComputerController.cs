using Api.Extensions;
using Application.UseCases.Computers.Commands.Add;
using Application.UseCases.Computers.Commands.Delete;
using Application.UseCases.Computers.Commands.Update;
using Application.UseCases.Computers.Queries.GetAll;
using Application.UseCases.Computers.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/computer/")]
public class ComputerController(ISender sender) : ControllerWithMediatR(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetComputerAsync([FromQuery] GetComputerByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetComputersAsync(CancellationToken cancellationToken)
    {
        var result = await Send(new GetAllComputersQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPost]
    public async Task<IActionResult> AddComputerAsync([FromBody] AddComputerCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateComputerAsync([FromBody] UpdateComputerCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteComputerAsync([FromRoute] DeleteComputerCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }
}
