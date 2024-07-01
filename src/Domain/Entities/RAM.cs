using Domain.Abstractions;

namespace Domain.Entities;

public sealed class RAM : Entity<Guid>
{
    public int? Amount { get; private set; }
    public string? Unit { get; private set; }

    private RAM() { }

    private RAM(int amount, string unit)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Unit = unit;
    }

    public static RAM Create(int amount, string unit)
        => new RAM(amount, unit);

    public bool Update(int? amount, string? unit)
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

        return isChanged;
    }
}
