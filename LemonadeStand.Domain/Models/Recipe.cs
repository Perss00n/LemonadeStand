using LemonadeStand.Domain.Interfaces;

namespace LemonadeStand.Domain.Models;

public class Recipe : IRecipe
{

    public string Name { get; } = string.Empty;
    public Type AllowedFruit { get; }
    public decimal ConsumptionPerGlass { get; } = decimal.Zero;
    public decimal PricePerGlass { get; } = decimal.Zero;

    public Recipe(string name, Type allowedFruit, decimal consumptionPerGlass, decimal pricePerGlass)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        Name = name.Trim();

        if (!typeof(IFruit).IsAssignableFrom(allowedFruit))
            throw new ArgumentException("allowedFruit must implement IFruit interface", "allowedFruit");
        AllowedFruit = allowedFruit;

        if (consumptionPerGlass <= decimal.Zero)
            throw new ArgumentOutOfRangeException("consumptionPerGlass must be greater than zero", "consumptionPerGlass");
        ConsumptionPerGlass = consumptionPerGlass;

        if (pricePerGlass < decimal.Zero)
            throw new ArgumentOutOfRangeException("pricePerGlass cannot be negative", "pricePerGlass");
        PricePerGlass = pricePerGlass;
    }
}