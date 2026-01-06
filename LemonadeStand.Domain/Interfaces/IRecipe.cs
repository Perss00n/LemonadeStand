namespace LemonadeStand.Domain.Interfaces;

public interface IRecipe
{
    Type AllowedFruit { get; }
    decimal ConsumptionPerGlass { get; }
    string Name { get; }
    decimal PricePerGlass { get; }
}