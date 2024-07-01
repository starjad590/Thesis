using Domain.Abstractions;

namespace Domain.Entities;

public sealed class Storage : Entity<Guid>
{
    public int? Amount { get; private set; }
    public string? Unit { get; private set; }
    public string? Type { get; private set; }

    private Storage() { }

    private Storage(int amount, string unit, string type)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Unit = unit;
        Type = type;
    }

    public static Storage Create(int amount, string unit, string type)
        => new Storage(amount, unit, type);

    public bool Update(int? amount, string? unit, string? type)
    {
        bool isChanged = false;

        if (amount is not null && amount != Amount)
        {
            Amount = amount;
            isChanged = true;
        }

        if (unit is not null && unit != Unit)
        {
            Unit = unit;
            isChanged = true;
        }

        if (type is not null && type != Type)
        {
            Type = type;
            isChanged = true;
        }

        return isChanged;
    }
}
