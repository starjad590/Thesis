using Api.Extensions;
using Application.UseCases.RAM.Commands.Add;
using Application.UseCases.RAM.Commands.Delete;
using Application.UseCases.RAM.Commands.Update;
using Application.UseCases.RAM.Queries.GetAll;
using Application.UseCases.RAM.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/ram/")]
public class RAMController(ISender sender) : ControllerWithMediatR(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetRAMAsync([FromQuery] GetRAMByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllRAMAsync(CancellationToken cancellationToken)
    {
        var result = await Send(new GetAllRAMQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPost]
    public async Task<IActionResult> AddRAMAsync([FromBody] AddRAMCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateRAMAsync([FromBody] UpdateRAMCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteRAMAsync([FromRoute] DeleteRAMCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }
}
