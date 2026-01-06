using LemonadeStand.Application.DTOs;
using LemonadeStand.Domain.Interfaces;
using LemonadeStand.Application.Interfaces;

namespace LemonadeStand.Application.Services;

public class FruitPressService : IFruitPressService
{
    public FruitPressResult Produce(IRecipe recipe, ICollection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
    {
        if (recipe is null)
            throw new ArgumentNullException(nameof(recipe));
        if (fruits is null)
            throw new ArgumentNullException(nameof(fruits));
        if (orderedGlassQuantity <= 0)
            return new FruitPressResult { Success = false, Message = "Ordered glass quantity must be greater than zero.", Change = moneyPaid, FruitsUsed = 0, ProducedGlasses = 0, RemainingFruits = fruits.ToList().AsReadOnly() };

        decimal payment = moneyPaid;
        decimal totalPrice = recipe.PricePerGlass * orderedGlassQuantity;

        if (payment < totalPrice)
            return new FruitPressResult { Success = false, Message = "Insufficient payment.", Change = payment, FruitsUsed = 0, ProducedGlasses = 0, RemainingFruits = fruits.ToList().AsReadOnly() };

        var matchingFruits = fruits.Where(f => recipe.AllowedFruit.IsAssignableFrom(f.GetType())).ToList();

        var requiredFruitsDecimal = recipe.ConsumptionPerGlass * orderedGlassQuantity;
        var requiredFruitCount = Math.Max(0, (int)Math.Ceiling(requiredFruitsDecimal));

        if (matchingFruits.Count < requiredFruitCount)
            return new FruitPressResult { Success = false, Message = "Not enough matching fruit provided.", Change = payment, FruitsUsed = 0, ProducedGlasses = 0, RemainingFruits = fruits.ToList().AsReadOnly() };

        var fruitsToUse = matchingFruits.Take(requiredFruitCount).ToList();

        var remaining = new List<IFruit>(fruits);
        foreach (var used in fruitsToUse)
        {
            remaining.Remove(used);
        }

        decimal change = payment - totalPrice;

        return new FruitPressResult
        {
            Success = true,
            ProducedGlasses = orderedGlassQuantity,
            FruitsUsed = requiredFruitCount,
            Change = change,
            Message = "Produced successfully.",
            RemainingFruits = remaining.AsReadOnly()
        };
    }
}