using Domain.Abstractions;

namespace Domain.Entities;

public sealed class PowerSupply : Entity<Guid>
{
    public int? Amount { get; private set; }

    private PowerSupply() { }

    private PowerSupply(int amount)
    {
        Id = Guid.NewGuid();
        Amount = amount;
    }

    public static PowerSupply Create(int amount)
        => new PowerSupply(amount);

    public bool Update(int? amount)
    {
        bool isChanged = false;

        if (amount is not null && amount != Amount)
        {
            Amount = amount;
            isChanged = true;
        }

        return isChanged;
    }
}
