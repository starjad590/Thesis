using Application.Abstractions.Messaging;

namespace Application.UseCases.RAM.Queries.GetAll;

public sealed record GetAllRAMQuery() : IQuery<GetAllRAMResponse> { }
