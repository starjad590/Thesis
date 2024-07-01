using Application.Abstractions.Messaging;

namespace Application.UseCases.Storage.Queries.GetAll;

public sealed record GetAllStorageQuery() : IQuery<GetAllStorageResponse> { }
