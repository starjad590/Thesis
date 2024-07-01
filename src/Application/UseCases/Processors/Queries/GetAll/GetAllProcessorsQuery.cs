using Application.Abstractions.Messaging;

namespace Application.UseCases.Processors.Queries.GetAll;

public sealed record GetAllProcessorsQuery() : IQuery<GetAllProcessorsResponse> { }
