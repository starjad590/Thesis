using Application.Abstractions.Messaging;

namespace Application.UseCases.PowerSupply.Queries.GetById;

public sealed record GetPowerSupplyByIdQuery(Guid Id) : IQuery<GetPowerSupplyByIdResponse> { }
