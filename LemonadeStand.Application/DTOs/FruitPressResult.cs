using LemonadeStand.Domain.Interfaces;

namespace LemonadeStand.Application.DTOs;

public sealed class FruitPressResult
{
    public bool Success { get; init; }
    public int ProducedGlasses { get; init; }
    public int FruitsUsed { get; init; }
    public decimal Change { get; init; }
    public string Message { get; init; } = string.Empty;
    public IReadOnlyCollection<IFruit> RemainingFruits { get; init; } = new List<IFruit>();
}
