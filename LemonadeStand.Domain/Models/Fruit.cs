using LemonadeStand.Domain.Interfaces;

namespace LemonadeStand.Domain.Models;

public abstract class Fruit : IFruit
{
    public string Name { get; }

    protected Fruit(string name)
    {
        Name = name;
    }
}
