using Application.Abstractions.Messaging;

namespace Application.UseCases.Computers.Commands.Add;

public sealed record AddComputerCommand(
    Guid GraphicsCardId,
    Guid PowerSupplyId,
    Guid ProcessorId,
    Guid RAMId,
    Guid StorageId,
    int WeightInGrams,
    int USB_2 = 0,
    int USB_3 = 0,
    int USB_C = 0
    ) : ICommand<AddComputerResponse> { }
