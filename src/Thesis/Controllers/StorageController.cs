using Api.Extensions;
using Application.UseCases.Storage.Commands.Add;
using Application.UseCases.Storage.Commands.Delete;
using Application.UseCases.Storage.Commands.Update;
using Application.UseCases.Storage.Queries.GetAll;
using Application.UseCases.Storage.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/storage/")]
public class StorageController(ISender sender) : ControllerWithMediatR(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetStorageAsync([FromQuery] GetStorageByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllStorageAsync(CancellationToken cancellationToken)
    {
        var result = await Send(new GetAllStorageQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPost]
    public async Task<IActionResult> AddStorageAsync([FromBody] AddStorageCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateStorageAsync([FromBody] UpdateStorageCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteStorageAsync([FromRoute] DeleteStorageCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }
}
