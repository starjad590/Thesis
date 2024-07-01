using Application.Abstractions.Messaging;

namespace Application.UseCases.RAM.Queries.GetById;

public sealed record GetRAMByIdQuery(Guid Id) : IQuery<GetRAMByIdResponse> { }
