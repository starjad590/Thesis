using Application.Abstractions.Messaging;

namespace Application.UseCases.Processors.Queries.GetById;

public sealed record GetProcessorByIdQuery(Guid Id) : IQuery<GetProcessorByIdResponse> { }
