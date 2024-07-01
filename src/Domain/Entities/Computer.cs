using Domain.Abstractions;

namespace Domain.Entities
{
    public sealed class Computer : Entity<Guid>
    {
        public Guid GraphicsCardId { get; private set; }
        public Guid PowerSupplyId { get; private set; }
        public Guid ProcessorId { get; private set; }
        public Guid RAMId { get; private set; }
        public Guid StorageId { get; private set; }
        public Guid USBPortsId { get; private set; }
        public int? WeightInGrams { get; private set; }

        public GraphicsCard? GraphicsCard { get; set; }
        public PowerSupply? PowerSupply { get; set; }
        public Processor? Processor { get; set; }
        public RAM? RAM { get; set; }
        public Storage? Storage { get; set; }
        public USBPorts? USBPorts { get; set; }

        private Computer() { }

        private Computer(
            Guid graphicsCardId,
            Guid powerSupplyId,
            Guid processorId,
            Guid ramId,
            Guid storageId,
            int weightInGrams,
            int usb_2,
            int usb_3,
            int usb_C)
        {
            Id = Guid.NewGuid();
            GraphicsCardId = graphicsCardId;
            PowerSupplyId = powerSupplyId;
            ProcessorId = processorId;
            RAMId = ramId;
            StorageId = storageId;
            WeightInGrams = weightInGrams;
            USBPorts = USBPorts.Create(usb_2, usb_3, usb_C);
            USBPortsId = USBPorts.Id;
        }

        public static Computer Create(
            Guid graphicsCardId,
            Guid powerSupplyId,
            Guid processorId,
            Guid ramId,
            Guid storageId,
            int weightInGrams,
            int usb_2,
            int usb_3,
            int usb_C)
            => new Computer(
                graphicsCardId,
                powerSupplyId,
                processorId,
                ramId,
                storageId,
                weightInGrams,
                usb_2,
                usb_3,
                usb_C);

        public bool Update(
            Guid? graphicsCardId,
            Guid? powerSupplyId,
            Guid? processorId,
            Guid? ramId,
            Guid? storageId,
            int? weightInGrams,
            int? usb_2,
            int? usb_3,
            int? usb_C)
        {
            bool isChanged = false;

            if (graphicsCardId is not null && graphicsCardId != GraphicsCardId)
            {
                GraphicsCardId = graphicsCardId.Value;
                isChanged = true;
            }

            if (powerSupplyId is not null && powerSupplyId != PowerSupplyId)
            {
                PowerSupplyId = powerSupplyId.Value;
                isChanged = true;
            }

            if (processorId is not null && processorId != ProcessorId)
            {
                ProcessorId = processorId.Value;
                isChanged = true;
            }

            if (ramId is not null && ramId != RAMId)
            {
                RAMId = ramId.Value;
                isChanged = true;
            }

            if (storageId is not null && storageId != StorageId)
            {
                StorageId = storageId.Value;
                isChanged = true;
            }

            if (weightInGrams is not null && weightInGrams != WeightInGrams)
            {
                WeightInGrams = weightInGrams;
                isChanged = true;
            }

            if (usb_2 is not null && usb_2 != USBPorts?.USB_2)
            {
                USBPorts?.Update(usb_2, null, null);
                isChanged = true;
            }

            if (usb_3 is not null && usb_3 != USBPorts?.USB_3)
            {
                USBPorts?.Update(null, usb_3, null);
                isChanged = true;
            }

            if (usb_C is not null && usb_C != USBPorts?.USB_C)
            {
                USBPorts?.Update(null, null, usb_C);
                isChanged = true;
            }

            return isChanged;
        }
    }
}
