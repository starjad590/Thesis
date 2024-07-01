using Application.Abstractions.Messaging;

namespace Application.UseCases.Computers.Queries.GetAll;

public sealed record GetAllComputersQuery() : IQuery<GetAllComputersResponse> { }
