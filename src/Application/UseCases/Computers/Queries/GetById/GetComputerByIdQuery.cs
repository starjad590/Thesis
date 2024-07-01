using Application.Abstractions.Messaging;

namespace Application.UseCases.Computers.Queries.GetById;

public sealed record GetComputerByIdQuery(Guid Id) : IQuery<GetComputerByIdResponse> { }
