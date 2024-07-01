using Api.Extensions;
using Application.UseCases.PowerSupply.Commands.Add;
using Application.UseCases.PowerSupply.Commands.Delete;
using Application.UseCases.PowerSupply.Commands.Update;
using Application.UseCases.PowerSupply.Queries.GetAll;
using Application.UseCases.PowerSupply.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/powerSupply/")]
public class PowerSupplyController(ISender sender) : ControllerWithMediatR(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetPowerSupplyAsync([FromQuery] GetPowerSupplyByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetPowerSuppliesAsync(CancellationToken cancellationToken)
    {
        var result = await Send(new GetAllPowerSuppliesQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPost]
    public async Task<IActionResult> AddPowerSupplyAsync([FromBody] AddPowerSupplyCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.GetErrorResponse();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdatePowerSupplyAsync([FromBody] UpdatePowerSupplyCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeletePowerSupplyAsync([FromRoute] DeletePowerSupplyCommand command, CancellationToken cancellationToken)
    {
        var result = await Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : result.GetErrorResponse();
    }
}
