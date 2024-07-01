using Application.Abstractions.Messaging;

namespace Application.UseCases.Computers.Commands.Update;

public sealed record UpdateComputerCommand(
    Guid Id,
    Guid? GraphicsCardId,
    Guid? PowerSupplyId,
    Guid? ProcessorId,
    Guid? RAMId,
    Guid? StorageId,
    int? WeightInGrams,
    int? USB_2,
    int? USB_3,
    int? USB_C
    ) : ICommand { }
