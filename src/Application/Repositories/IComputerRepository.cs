using Application.Repositories.Base;
using Domain.Entities;

namespace Application.Repositories;

public interface IComputerRepository : IGenericRepository<Computer>
{
    Task<Computer?> CheckIfExistsAsync(
            Guid graphicsCardId,
            Guid powerSupplyId,
            Guid processorId,
            Guid ramId,
            Guid storageId,
            int weightInGrams,
            int usb_2 = 0,
            int usb_3 = 0,
            int usb_c = 0);

    Task<Computer?> GetByComputerIdAsync(Guid computerId);

    Task<List<Computer>> GetAllComputersAsync();
}
