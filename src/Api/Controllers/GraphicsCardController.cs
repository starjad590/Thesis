using Api.Extensions;
using Application.UseCases.GraphicsCards.Commands.Add;
using Application.UseCases.GraphicsCards.Commands.Delete;
using Application.UseCases.GraphicsCards.Commands.Update;
using Application.UseCases.GraphicsCards.Queries.GetAll;
using Application.UseCases.GraphicsCards.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/graphicsCard/")]
public class GraphicsCardController(ISender sender) : ControllerWithMediatR(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetGraphicsCardAsync([FromQuery] GetGraphicsCardByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetGraphicsCardsAsync(CancellationToken cancellationToken)
    {
        var result = await Send(new GetAllGraphicsCardsQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPost]
    public async Task<IActionResult> AddGraphicsCardAsync([FromBody] AddGraphicsCardCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateGraphicsCardAsync([FromBody] UpdateGraphicsCardCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteGraphicsCardAsync([FromRoute] DeleteGraphicsCardCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }
}
