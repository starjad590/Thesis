using Domain.Abstractions;

namespace Domain.Entities;

public sealed class USBPorts : Entity<Guid>
{
    public int? USB_2 { get; private set; }
    public int? USB_3 { get; private set; }
    public int? USB_C { get; private set; }

    private USBPorts() { }

    private USBPorts(int usb_2 = 0, int usb_3 = 0, int usb_c = 0)
    {
        Id = Guid.NewGuid();
        USB_2 = usb_2;
        USB_3 = usb_3;
        USB_C = usb_c;
    }

    public static USBPorts Create(int usb_2 = 0, int usb_3 = 0, int usb_c = 0)
        => new USBPorts(usb_2, usb_3, usb_c);

    public bool Update(int? usb_2, int? usb_3, int? usb_c)
    {
        bool isChanged = false;

        if (usb_2 is not null && usb_2 != USB_2)
        {
            USB_2 = usb_2;
            isChanged = true;
        }

        if (usb_3 is not null && usb_3 != USB_3)
        {
            USB_3 = usb_3;
            isChanged = true;
        }

        if (usb_c is not null && usb_c != USB_C)
        {
            USB_C = usb_c;
            isChanged = true;
        }

        return isChanged;
    }
}
