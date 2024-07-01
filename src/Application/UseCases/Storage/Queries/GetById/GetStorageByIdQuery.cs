using Application.Abstractions.Messaging;

namespace Application.UseCases.Storage.Queries.GetById;

public sealed record GetStorageByIdQuery(Guid Id) : IQuery<GetStorageByIdResponse> { }
