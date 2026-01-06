using LemonadeStand.Application.DTOs;
using LemonadeStand.Domain.Interfaces;

namespace LemonadeStand.Application.Interfaces;

public interface IFruitPressService
{
    FruitPressResult Produce(IRecipe recipe, ICollection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity);
}
