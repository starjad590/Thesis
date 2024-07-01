using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ComputerRepository : GenericRepository<Computer>, IComputerRepository
    {
        public ComputerRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Computer?> CheckIfExistsAsync(
            Guid graphicsCardId,
            Guid powerSupplyId,
            Guid processorId,
            Guid ramId,
            Guid storageId,
            int weightInGrams,
            int usb_2 = 0,
            int usb_3 = 0,
            int usb_c = 0)
        {
            return await _context.Computers.Where(x => 
                x.GraphicsCardId == graphicsCardId && 
                x.PowerSupplyId == powerSupplyId && 
                x.ProcessorId == processorId &&
                x.RAMId == ramId &&
                x.StorageId == storageId &&
                x.WeightInGrams == weightInGrams &&
                x.USBPorts.USB_2 == usb_2 &&
                x.USBPorts.USB_3 == usb_3 &&
                x.USBPorts.USB_C == usb_c
            ).FirstOrDefaultAsync();
        }

        public async Task<Computer?> GetByComputerIdAsync(Guid computerId)
        {
            return await _context.Computers
                .Include(c => c.GraphicsCard)
                .Include(c => c.PowerSupply)
                .Include(c => c.Processor)
                .Include(c => c.RAM)
                .Include(c => c.Storage)
                .Include(c => c.USBPorts)
                .FirstOrDefaultAsync(c => c.Id == computerId);
        }

        public async Task<List<Computer>> GetAllComputersAsync()
        {
            return await _context.Computers
                .Include(c => c.GraphicsCard)
                .Include(c => c.PowerSupply)
                .Include(c => c.Processor)
                .Include(c => c.RAM)
                .Include(c => c.Storage)
                .Include(c => c.USBPorts)
                .ToListAsync();
        }
    }
}
