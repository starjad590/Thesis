using Application.Abstractions.Messaging;

namespace Application.UseCases.PowerSupply.Queries.GetAll;

public sealed record GetAllPowerSuppliesQuery() : IQuery<GetAllPowerSuppliesResponse> { }
